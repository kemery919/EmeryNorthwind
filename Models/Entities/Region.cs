using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  // This allows the ability to change the name of the table to 
  // match the data without changing the class to plural
  [Table("Regions")]
  public class Region {
    [Key]
    public int RegionID { get; set; } = default!;
    public string? RegionDescription { get; set; }
  }
}