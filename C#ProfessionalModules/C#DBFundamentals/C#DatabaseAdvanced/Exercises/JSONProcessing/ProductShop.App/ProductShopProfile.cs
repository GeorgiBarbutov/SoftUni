namespace ProductShop.App
{
    using AutoMapper;

    using Dto.ImportDtos;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
