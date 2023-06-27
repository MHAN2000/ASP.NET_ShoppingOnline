using AutoMapper;
using ShoppingOnline.Models.DTO;

namespace ShoppingOnline.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
