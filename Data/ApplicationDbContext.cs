using Microsoft.EntityFrameworkCore;
using EmeryNorthwind.Models.Entities;

namespace EmeryNorthwind.Data;

public class ApplicationDbContext : DbContext {
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
    }
  public DbSet<Category>? Catergories { get; set; }
  public DbSet<Customer>? Customers { get; set; }
  public DbSet<CustomerCustomerDemo>? CustomerCustomerDemos { get; set; }
  public DbSet<CustomerDemographics>? CustomerDemographics { get; set; }
  public DbSet<Employee>? Employees { get; set; }
  public DbSet<EmployeeTerritory>? EmployeeTerritories { get; set; }
  public DbSet<Order>? Orders { get; set; }
  public DbSet<OrderDetails>? OrderDetails { get; set; }
  public DbSet<Product>? Products { get; set; }
  public DbSet<Region>? Regions { get; set; }
  public DbSet<Shipper>? Shippers { get; set; }
  public DbSet<Supplier>? Suppliers { get; set; }
  public DbSet<Territory>? Territories { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<CustomerCustomerDemo>()
          .HasKey(ccd => new { ccd.CustomerId, ccd.CustomerTypeId });
        modelBuilder.Entity<EmployeeTerritory>()
          .HasKey(et => new { et.EmployeeId, et.TerritoryId });
        modelBuilder.Entity<OrderDetails>()
          .HasKey(od => new { od.OrderId, od.ProductId });

    }
}