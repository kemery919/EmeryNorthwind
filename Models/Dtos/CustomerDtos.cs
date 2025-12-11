using EmeryNorthwind.Models.Entities;

namespace EmeryNorthwind.Models.Dtos;

public class CustomerDto {
    
    public string? CompanyName { get; set; }
    public string CustomerId { get; set; } = default!;
    public string? Country { get; set; } 
    public int? OrderCount { get; set; }
}

public class OrderSummaryDto {
    public string CustomerId { get; set; }
    public string? ContactName { get; set; }
    public int TotalOrders { get; set; }
    public DateTime? FirstOrderDate { get; set; }
    public DateTime? MostRecentOrderDate { get; set; }
    public double Total { get; set; }
}