// Models/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace AuthECAPI.Models
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RegUsers> RegUsers { get; set; }
  }
}
