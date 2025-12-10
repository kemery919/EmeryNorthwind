using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  public class EmployeeTerritory {
    [Key]
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; } = default!;
    [Key]
    [ForeignKey("Territory")]
    public string TerritoryId { get; set; } = default!;
    public virtual Employee Employee { get; set; } = default!;
    public virtual Territory Territory { get; set; } = default!;
  }
}