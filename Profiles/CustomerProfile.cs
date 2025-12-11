using AutoMapper;
using EmeryNorthwind.Models.Entities;
using EmeryNorthwind.Models.Dtos;

public class CustomerProfile : Profile {
  public CustomerProfile() {
    CreateMap<CustomerDto, Customer>().ReverseMap();
  }
}