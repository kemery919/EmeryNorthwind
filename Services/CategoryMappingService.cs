using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

namespace EmeryNorthwind.Services.Mapping;

public class CategoryMappingService {

  private readonly IMapper _mapper;

  public CategoryMappingService(IMapper mapper){
      _mapper = mapper;
  }

  public CategoryDto MapToCategoryDto(Category category){
      return _mapper.Map<CategoryDto>(category);
  }

  public Category MapToCategory(CategoryDto categoryDto){
      return _mapper.Map<Category>(categoryDto);
  }
}