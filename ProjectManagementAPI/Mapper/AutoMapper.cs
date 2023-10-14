using AutoMapper;
using Microsoft.Extensions.Hosting;
using ProjectManagementAPI.Dtos;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
