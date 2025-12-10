using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  public class CustomerDemographics {
    [Key]
    public string CustomerDemographicsId { get; set; } = default!;
    public string CustomerDesc { get; set; } = default!;
  }
}