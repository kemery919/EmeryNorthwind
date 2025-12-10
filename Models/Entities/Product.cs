using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  // This allows the ability to change the name of the table to 
  // match the data without changing the class to plural
  [Table("Products")]
  public class Product {
    [Key]
    public int ProductId { get; set; } = default!;
    public string? ProductName { get; set; }
    [ForeignKey("Supplier")]
    public int? SupplierId { get; set; }
    public virtual Supplier? Supplier { get; set; }
    [ForeignKey("Category")]
    public int? CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public string? QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool? Discontinued { get; set; }
  }
}