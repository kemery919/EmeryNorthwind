using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

namespace EmeryNorthwind.Services.Mapping;

public class ProductMappingService {

  private readonly IMapper _mapper;

  public ProductMappingService(IMapper mapper){
      _mapper = mapper;
  }

}