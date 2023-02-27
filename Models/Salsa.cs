using System.ComponentModel.DataAnnotations;

namespace BurritoBoysApi.Models
{
  public class Salsa 
  {
    public int SalsaId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    
    public int SpotId { get; set; }
  }
}