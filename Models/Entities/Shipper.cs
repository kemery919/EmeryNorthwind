using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  // This allows the ability to change the name of the table to 
  // match the data without changing the class to plural
  [Table("Shippers")]
  public class Shipper {
    [Key]
    public int ShipperID { get; set; } = default!;
    public string? CompanyName { get; set; }
    public string? Phone { get; set; }
  }
}