using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  public class OrderDetails {
    [Key]
    [ForeignKey("Order")]
    public int OrderId { get; set; } = default!;
    public virtual Order Order { get; set; } = default!;
    [Key]
    [ForeignKey("Product")]
    public int ProductId { get; set; } = default!;
    public virtual Product Product { get; set; } = default!;
    public decimal? UnitPrice { get; set; }
    public int? Quantity { get; set; }
    public decimal? Discount { get; set; }
  }
}