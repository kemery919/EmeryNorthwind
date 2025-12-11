using EmeryNorthwind.Models.Entities;

namespace EmeryNorthwind.Models.Dtos;

public class CategoryDto {
  public string CategoryName { get; set; } = default!;
  public string? Description { get; set; }
}