using System;
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

    // api/products
    [HttpGet("")] 
    public async Task<ActionResult<List<ProductDto>>> GetProducts() {
      var products = await _context.Products.Select(p => _productMappingService.MapToProductDto(p)).ToListAsync();
      
      return Ok(products);
    }

    // api/products/by-category
    [HttpGet("by-category")] 
    public async Task<ActionResult<List<ProductDto>>> GetProductsByCategory() {
      var products = await _context.Products.Include(p => p.Category).ToListAsync();

      var extraProductDtos = products.Select(p => _productMappingService.MapToExtraProductDto(p)).ToList();

      var productDtos = extraProductDtos.Select(p => _productMappingService.MapToExProductDto(p)).ToList();

      var productsByCategory = productDtos.GroupBy(p => p.CategoryName).ToDictionary(p => p.Key, p => p.ToList());
      
      return Ok(productsByCategory);
    }

    // api/products/category/{categoryId}
    [HttpGet("category/{categoryId}")] 
    public async Task<ActionResult<List<ProductDto>>> GetProductsByCategory(int categoryId) {
      var products = await _context.Products
        .Include(p => p.Category)
        .Where(p => p.CategoryId == categoryId)
        .OrderBy(p => p.ProductName)
        .ToListAsync();

      var extraProductDtos = products.Select(p => _productMappingService.MapToExtraProductDto(p)).ToList();

      var productDtos = extraProductDtos.Select(p => _productMappingService.MapToExProductDto(p)).ToList();

      return Ok(productDtos);
    }

    // api/products/category/low-stock?threshold={threshold}

    // Tested this by manually entering the following to ensure it followed the above layout:
    // localhost:5000/api/products/category/low-stock?threshold=16
    // localhost:5000/api/products/category/low-stock?threshold=-1    ->    This triggers the error message

    [HttpGet("category/low-stock")]
    public async Task<ActionResult<List<ProductDto>>> GetLowStockProducts([FromQuery]int threshold) {
      if (threshold == null){threshold = 10;}
      
      if (threshold < 0){return BadRequest("Threshold must be greater than 0.");}
      
      var products = await _context.Products
        .Include(p => p.Category)
        .Where(p => p.UnitsInStock <= threshold)
        .Where(p => p.Discontinued == false)
        .OrderBy(p => (double)p.UnitPrice)
        .ToListAsync();

      var extraProductDtos = products.Select(p => _productMappingService.MapToExtraProductDto(p)).ToList();

      var productDtos = extraProductDtos.Select(p => _productMappingService.MapToExProductDto(p)).ToList();

      var productDtosList = productDtos.GroupBy(p => p.CategoryName).OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.ToList());

      return Ok(productDtosList);
    }

    // api/products/category/average-price-by-category
    [HttpGet("category/average-price-by-category")] 
    public async Task<ActionResult<List<ProductDto>>> GetAveragePriceByCategory() {
      var products = await _context.Products.Include(p => p.Category).ToListAsync();

      var extraProductDtos = products.Select(p => _productMappingService.MapToExtraProductDto(p)).ToList();

      var productDtos = extraProductDtos.Select(p => _productMappingService.MapToExProductDto(p)).ToList();

      // Refer back to the following line for the Math.Round() method
      var averagePriceByCategory = productDtos.GroupBy(p => p.CategoryName).ToDictionary(p => p.Key, p => Math.Round(p.Average(p => (double)p.UnitPrice), 2));
      
      return Ok(averagePriceByCategory);
    }

    // api/products/category/most-expensive?count={count}
    [HttpGet("category/most-expensive")]
    public async Task<ActionResult<List<ProductDto>>> GetMostExpensiveProducts([FromQuery]int count) {
      
      if (count == 0){count = 5;}

      if (count < 0){ return BadRequest("Count must be greater than 0."); }

      var products = await _context.Products.Include(p => p.Category).ToListAsync();

      var extraProductDtos = products.Select(p => _productMappingService.MapToExtraProductDto(p)).ToList();

      var productDtos = extraProductDtos.Select(p => _productMappingService.MapToExProductDto(p))
                                        .OrderByDescending(p => p.UnitPrice)
                                        .Take(count)
                                        .ToList();
      
      return Ok(productDtos);
    }

    // /api/products/most-expensive-by-category?count={count}
    [HttpGet("category/most-expensive-by-category")]
    public async Task<ActionResult<List<ProductDto>>> GetMostExpensiveProductsByCategory([FromQuery]int count) {
      
      if (count == 0){count = 5;}

      if (count < 0){ return BadRequest("Count must be greater than 0."); }

      var products = await _context.Products.Include(p => p.Category).ToListAsync();

      var extraProductDtos = products.Select(p => _productMappingService.MapToExtraProductDto(p)).ToList();

      var productDtos = extraProductDtos.Select(p => _productMappingService.MapToExProductDto(p)).ToList();

      var mostExpensiveProducts = productDtos.GroupBy(p => p.CategoryName).ToDictionary(p => p.Key, p => p.OrderByDescending(p => p.UnitPrice).Take(count).ToList());
      
      return Ok(mostExpensiveProducts);
    }
  }
}