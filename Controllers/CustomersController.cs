using EmeryNorthwind.Data;
using EmeryNorthwind.Models.Dtos;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Services.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmeryNorthwind.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase {
    private readonly ApplicationDbContext _context;
    private readonly CustomerMappingService _customerMappingService;
    public CustomersController(
      ApplicationDbContext context,
      CustomerMappingService customerMappingService
    ) {
      _context = context;
      _customerMappingService = customerMappingService;
    }

    // api/customers/by-country
    [HttpGet("by-country")]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomersByCountry() {
      var customers = await _context.Customers.ToListAsync();

      var customersDto = customers.Select(_customerMappingService.MapToCustomerDto).ToList();

      var customersByCountry = customersDto
        .GroupBy(c => c.Country ?? "No Country Listed")
        .OrderBy(c => c.Key)
        .ToDictionary(c => c.Key, c => c.OrderBy(c => c.CompanyName).ToList());
      
      return Ok(customersByCountry);
    }

    // api/customers/no-orders
    [HttpGet("no-orders")]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomersWithNoOrders() {
      var customersWithOrders = await _context.Customers
        .Where(c => _context.Orders.Any(o => o.CustomerId == c.CustomerId))
        .ToListAsync();

      // There is 100% a better way to do this but this is what I settled on for now.

      var allCustomers = await _context.Customers.ToListAsync();

      var customersWithNoOrders = allCustomers
        .Except(customersWithOrders)
        .Select(_customerMappingService.MapToCustomerDto).ToList();

      return Ok(customersWithNoOrders);
    }

    // api/customers/{customerId}/order-summary
    [HttpGet("{customerId}/order-summary")]
    public async Task<ActionResult<OrderSummaryDto>> GetOrderSummary(string customerId) {
      
      var exists = await _context.Customers.AnyAsync(c => c.CustomerId == customerId);

      if (!exists) { return NotFound($"No customer found with id: {customerId}"); }
      
      var orders = await _context.OrderDetails
        .Include(od => od.Order)
          .ThenInclude(o => o.Customer)
        .Where(od => od.Order.CustomerId == customerId)
        .OrderBy(od => od.Order.OrderDate)
        .ToListAsync();

      var orderSummary = new OrderSummaryDto();

      var fetchContactName = await _context.Customers
        .Where(c => c.CustomerId == customerId)
        .Select(c => c.ContactName)
        .FirstOrDefaultAsync();
      
      orderSummary.CustomerId = customerId;
      orderSummary.ContactName = orders.Any() ? orders[0].Order.Customer.ContactName : fetchContactName;
      orderSummary.TotalOrders = orders.Count > 0 ? orders.Count : 0;
      orderSummary.FirstOrderDate = orders.Count > 0 ? orders[0].Order.OrderDate : (DateTime?)null;
      orderSummary.MostRecentOrderDate = orders.Count > 0 ? orders[orders.Count - 1].Order.OrderDate : (DateTime?)null;
      orderSummary.Total = orders.Count > 0 ? (double)orders.Sum(od => od.Discount > 0 ? od.Quantity * (od.UnitPrice * (1 - od.Discount)) : od.Quantity * od.UnitPrice) : 0.0;
      orderSummary.Total = Math.Round(orderSummary.Total, 2);

      return Ok(orderSummary);
    }

  }
}