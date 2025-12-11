using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

public class CategoryProfile : Profile {
  public CategoryProfile() {
    CreateMap<Category, CategoryDto>().ReverseMap();
  }
}