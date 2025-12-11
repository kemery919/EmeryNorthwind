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
  public class ProductsController : ControllerBase {
    private readonly ApplicationDbContext _context;
    private readonly ProductMappingService _productMappingService;
    public ProductsController(
      ApplicationDbContext context,
      ProductMappingService productMappingService
    ) {
      _context = context;
      _productMappingService = productMappingService;
    }
  }
}