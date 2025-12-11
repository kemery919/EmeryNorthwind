using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

public class ProductProfile : Profile {
  public ProductProfile() {
    CreateMap<ProductDto, Product>().ReverseMap();
    CreateMap<ExtraProductDto, Product>().ReverseMap();
    CreateMap<ExtraProductDto, ProductDto>().ReverseMap();
  }
}