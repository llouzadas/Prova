using Microsoft.AspNetCore.Mvc;
using FreightSystem.Data;
using FreightSystem.Models;
using System.Linq;
// Outras diretivas using...

#nullable enable

namespace FreightSystem.Data;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly AppDbContext _context;

    public VehicleController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Vehicles.ToList());
    }

    [HttpPost]
    public IActionResult Create(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = vehicle.Id }, vehicle);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Vehicle vehicle)
    {
        var existingVehicle = _context.Vehicles.Find(id);
        if (existingVehicle == null)
        {
            return NotFound();
        }

        existingVehicle.Name = vehicle.Name;
        existingVehicle.WeightFactor = vehicle.WeightFactor;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var vehicle = _context.Vehicles.Find(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        _context.SaveChanges();
        return NoContent();
    }
}
