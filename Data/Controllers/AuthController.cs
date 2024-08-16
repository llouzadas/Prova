using Microsoft.AspNetCore.Mvc;
using FreightSystem.Data;
using FreightSystem.Models;
using System.Linq;
// Outras diretivas using...

#nullable enable

namespace FreightSystem.Data;



[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User login)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == login.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(login.PasswordHash, user.PasswordHash))
        {
            return Unauthorized();
        }

        return Ok(new { message = "Login successful" });
    }
}
