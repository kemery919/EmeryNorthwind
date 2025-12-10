using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  public class CustomerCustomerDemo {
    [Key]
    [ForeignKey("Customer")]
    public string CustomerId { get; set; } = default!;
    [Key]
    [ForeignKey("CustomerDemographics")]
    public string CustomerTypeId { get; set; } = default!;
    public virtual Customer Customer { get; set; } = default!;
    public virtual CustomerDemographics CustomerDemographics { get; set; } = default!;
  }
}