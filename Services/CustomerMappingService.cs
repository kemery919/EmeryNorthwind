using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

namespace EmeryNorthwind.Services.Mapping;

public class CustomerMappingService {

  private readonly IMapper _mapper;

  public CustomerMappingService(IMapper mapper){
      _mapper = mapper;
  }

}