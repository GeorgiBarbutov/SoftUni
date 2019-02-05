using AutoMapper;
using ProductShop.App.Dtos;
using ProductShop.Models;
using System.Linq;

namespace ProductShop.App
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductsInRangeDto>()
                .ForMember(dest => dest.BuyerName,
                           opt => opt.MapFrom(src => src.Buyer.FirstName + " " + src.Buyer.LastName));
            CreateMap<User, UserSoldProductDto>()
                .ForMember(dest => dest.SoldProduct,
                           opt => opt.MapFrom(src => src.SoldProducts));
            CreateMap<Category, CategoriesPerProductCountDto>()
                .ForMember(dest => dest.NumberOfProducts,
                           opt => opt.MapFrom(src => src.Products.Count))
                .ForMember(dest => dest.AveragePricePerProduct,
                           opt => opt.MapFrom(src => src.Products.Average(p => p.Product.Price)))
                .ForMember(dest => dest.TotalRevenue,
                           opt => opt.MapFrom(src => src.Products.Sum(p => p.Product.Price)));
        }
    }
}
