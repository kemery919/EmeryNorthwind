using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

namespace EmeryNorthwind.Services.Mapping;

public class ProductMappingService {

  private readonly IMapper _mapper;

  public ProductMappingService(IMapper mapper){
      _mapper = mapper;
  }

  public ProductDto MapToProductDto(Product product){
    return _mapper.Map<ProductDto>(product);
  }

  public Product MapToProduct(ProductDto productDto){
    return _mapper.Map<Product>(productDto);
  }

  public ExtraProductDto MapToExtraProductDto(Product product){
    return _mapper.Map<ExtraProductDto>(product);
  }

  public Product MapToExtraProductDto(ExtraProductDto extraProductDto){
    return _mapper.Map<Product>(extraProductDto);
  }

  public ProductDto MapToExProductDto(ExtraProductDto extraProductDto){
    return _mapper.Map<ProductDto>(extraProductDto);
  }

  public ExtraProductDto MapToExProductDto(ProductDto productDto){
    return _mapper.Map<ExtraProductDto>(productDto);
  }

}