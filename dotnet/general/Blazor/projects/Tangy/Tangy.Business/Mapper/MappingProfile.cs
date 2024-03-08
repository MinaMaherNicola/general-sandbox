using AutoMapper;
using Tangy.DataAccess.Data.Models;
using Tangy.Models.DTOs;

namespace Tangy.Business.Mapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductPrice, ProductPriceDto>().ReverseMap();
        }
    }
}
