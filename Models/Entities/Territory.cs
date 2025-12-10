using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  // This allows the ability to change the name of the table to 
  // match the data without changing the class to plural
  [Table("Territories")]
  public class Territory {
    [Key]
    public string TerritoryID { get; set; } = default!;
    public string TerritoryDescription { get; set; } = default!;
    [ForeignKey("RegionID")]
    public int? RegionID { get; set; }
    public virtual Region? Region { get; set; }
  }
}