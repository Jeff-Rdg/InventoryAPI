using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class ProductDTOProfile : Profile
    {
        public ProductDTOProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
