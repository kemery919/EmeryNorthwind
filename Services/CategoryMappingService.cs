using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

namespace EmeryNorthwind.Services.Mapping;

public class CategoryMappingService {

  private readonly IMapper _mapper;

  public CategoryMappingService(IMapper mapper){
      _mapper = mapper;
  }

}