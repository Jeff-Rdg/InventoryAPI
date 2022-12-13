using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.InventoryDto;
using InventoryAPI.DTO.ProductTypeDto;

using InventoryAPI.Model;
using InventoryAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Profiles
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<Product, ProductDto>();
            CreateMap<Inventory, InventoryDto>();

            CreateMap<IdentityUser, UserModel>();
        }
    }
}
