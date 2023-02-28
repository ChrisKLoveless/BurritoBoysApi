using System.ComponentModel.DataAnnotations;

namespace BurritoBoysApi.Models
{
  public class Spot
  {
    public int SpotId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string City { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public double AverageRating { get; set; }
    public List<Rating> Ratings { get; set; }
    public List<Salsa> Salsas { get; set; }
  }
}