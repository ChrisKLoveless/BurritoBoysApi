using System.ComponentModel.DataAnnotations;

namespace BurritoBoysApi.Models
{
  public class Spot
  {
    public int SpotId { get; set; }
    [Required]
    public string Name { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
  }
}