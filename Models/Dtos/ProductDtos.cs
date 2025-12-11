using EmeryNorthwind.Models.Entities;

namespace EmeryNorthwind.Models.Dtos;

public class ProductDto {
  public int ProductId { get; set; }
  public string ProductName { get; set; } = null!;
  public int SupplierId { get; set; }
  public int CategoryId { get; set; }
  public string CategoryName { get; set; }
  public string QuantityPerUnit { get; set; } = null!;
  public decimal UnitPrice { get; set; }
  public short UnitsInStock { get; set; }
  public short UnitsOnOrder { get; set; }
  public short ReorderLevel { get; set; }
  public bool Discontinued { get; set; }
  public bool ProofOfDto { get; set; } = true;
}

public class ExtraProductDto {
  public int ProductId { get; set; }
  public string ProductName { get; set; } = null!;
  public int SupplierId { get; set; }
  public int CategoryId { get; set; }
  public virtual Category? Category { get; set; }
  public string CategoryName => Category?.CategoryName ?? string.Empty;
  public string QuantityPerUnit { get; set; } = null!;
  public decimal UnitPrice { get; set; }
  public short UnitsInStock { get; set; }
  public short UnitsOnOrder { get; set; }
  public short ReorderLevel { get; set; }
  public bool Discontinued { get; set; }
  public bool ProofOfDto { get; set; } = true;
}