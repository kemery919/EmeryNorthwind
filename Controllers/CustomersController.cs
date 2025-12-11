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
  }
}