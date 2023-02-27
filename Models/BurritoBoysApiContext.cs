namespace BurritoBoysApi.Models
{
  public class BurritoBoysApiContext : DbContext
  {
    public DbSet<Spot> Spots { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Salsa> Salsas { get; set; }

    public BurritoBoysApiContext(DbContextOptions<BurritoBoysApiContext> options) : base(options)
    {
    }
  }
}