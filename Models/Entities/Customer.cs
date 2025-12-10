using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmeryNorthwind.Models.Entities {
  // This allows the ability to change the name of the table to 
  // match the data without changing the class to plural
  [Table("Customers")]
  public class Customer {
    [Key]
    public string CustomerId { get; set; } = default!;
    public string? CompanyName { get; set; }
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Address { get; set; } 
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; } 
    public string? Phone { get; set; }
    public string? Fax { get; set; } 
  }
}