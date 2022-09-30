using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
