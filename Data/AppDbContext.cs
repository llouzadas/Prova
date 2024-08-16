using Microsoft.EntityFrameworkCore;
using FreightSystem.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Freight> Freights { get; set; }
    public DbSet<User> Users { get; set; }
}
