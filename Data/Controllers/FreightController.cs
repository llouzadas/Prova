using Microsoft.AspNetCore.Mvc;
using FreightSystem.Data;
using FreightSystem.Models;
using System.Linq;
using System.Collections.Generic;

#nullable enable

namespace FreightSystem.Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreightController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FreightController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Freight>> GetAll()
        {
            var freights = _context.Freights.ToList();
            return Ok(freights);
        }

        [HttpPost]
        public IActionResult Create(Freight freight)
        {
            var vehicle = _context.Vehicles.Find(freight.VehicleId);
            if (vehicle == null)
            {
                return BadRequest("Invalid vehicle ID.");
            }

            freight.BasePrice = freight.Distance * vehicle.WeightFactor;
            freight.FinalPrice = CalculateFinalPrice(freight.BasePrice, freight.Distance);
            _context.Freights.Add(freight);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = freight.Id }, freight);
        }

        private decimal CalculateFinalPrice(decimal basePrice, int distance)
        {
            decimal rate = distance switch
            {
                <= 100 => 0.20m,
                <= 200 => 0.15m,
                <= 500 => 0.10m,
                _ => 0.075m,
            };
            return basePrice * (1 - rate);
        }
    }
}