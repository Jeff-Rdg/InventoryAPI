using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.InventoryDto;
using InventoryAPI.DTO.ProductTypeDto;

using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<Product, ProductDto>();
            CreateMap<Inventory, InventoryDto>();
        }
    }
}
