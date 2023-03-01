using Microsoft.EntityFrameworkCore;

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
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Spot>()
        .HasData(
          new Spot { SpotId = 1, Name = "Robertos", State = "NV", City = "Las Vegas", Address = "1122 S Maryland Pkwy suite 110", Website = "www.Robertos.com", AverageRating = 4.66 },
          new Spot { SpotId = 2, Name = "Muchas Gracias", State = "OR", City = "Portland", Address = "707 NE Weidler St", Website = "www.MuchasGracias.com", AverageRating = 3.33 },
          new Spot { SpotId = 3, Name = "Pinches Burros", State = "OR", City = "Portland", Address = "5745 NE Prescott St", Website = "www.PinchesBurros.com", AverageRating = 5 },
          new Spot { SpotId = 4, Name = "King Burrito", State = "OR", City = "Portland", Address = "3503 N Mississippi Ave", Website = "www.KingBurrito.com", AverageRating = 4.33 },
          new Spot { SpotId = 5, Name = "Los Francos", State = "OR", City = "Portland", Address = "If you know, You know", Website = "food", AverageRating = 4 }
        );
      builder.Entity<Rating>()
        .HasData(
          new Rating { RatingId = 1, Rate = 5, SpotId = 1 },
          new Rating { RatingId = 2, Rate = 4, SpotId = 1 },
          new Rating { RatingId = 3, Rate = 5, SpotId = 1 },
          new Rating { RatingId = 4, Rate = 4, SpotId = 2 },
          new Rating { RatingId = 5, Rate = 3, SpotId = 2 },
          new Rating { RatingId = 6, Rate = 3, SpotId = 2 },
          new Rating { RatingId = 7, Rate = 5, SpotId = 3 },
          new Rating { RatingId = 8, Rate = 5, SpotId = 3 },
          new Rating { RatingId = 9, Rate = 5, SpotId = 3 },
          new Rating { RatingId = 10, Rate = 4, SpotId = 4 },
          new Rating { RatingId = 11, Rate = 4, SpotId = 4 },
          new Rating { RatingId = 12, Rate = 5, SpotId = 4 },
          new Rating { RatingId = 13, Rate = 4, SpotId = 5 },
          new Rating { RatingId = 14, Rate = 4, SpotId = 5 },
          new Rating { RatingId = 15, Rate = 4, SpotId = 5 }
        );
      builder.Entity<Salsa>()
        .HasData(
          new Salsa { SalsaId = 1, Name = "Green Salsa", Description = "Mild but delicious.", SpotId = 1 },
          new Salsa { SalsaId = 2, Name = "Avocado Salsa", Description = "Medium spicy and creamy..", SpotId = 2 },
          new Salsa { SalsaId = 3, Name = "Chipotle Salsa", Description = "Smokey and spicy.", SpotId = 3 },
          new Salsa { SalsaId = 4, Name = "Habenero Salsa", Description = "Spicy.", SpotId = 4 },
          new Salsa { SalsaId = 5, Name = "Red Salsa", Description = "Firey.", SpotId = 5 }
        );
    }
  }
}