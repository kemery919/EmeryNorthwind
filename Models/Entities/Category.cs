using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  // This allows the ability to change the name of the table to 
  // match the data without changing the class to plural
  [Table("Categories")]
  public class Category {
    [Key]
    public int CategoryId { get; set; } = default!;
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public byte[]? Image { get; set; }
  }
}