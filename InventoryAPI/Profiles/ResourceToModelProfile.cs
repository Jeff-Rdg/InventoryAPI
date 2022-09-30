using AutoMapper;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateProductTypeDto, ProductType>();
            CreateMap<ProductTypeDto, ProductType>();
        }
    }
}
