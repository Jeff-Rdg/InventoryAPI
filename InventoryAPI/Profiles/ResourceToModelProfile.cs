using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.InventoryDto;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.DTO.ProviderDto;
using InventoryAPI.DTO.StorageDto;
using InventoryAPI.Model;
using InventoryAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Profiles
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<ProductTypeDTO, ProductType>();

            CreateMap<ProductDto, Product>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<CreateStorageDto, Storage>();

            CreateMap<CreateProviderDto, Provider>();

            CreateMap<InventoryDto, Inventory>();
            CreateMap<CreateInventoryDto, Inventory>();
            CreateMap<UpdateInventoryDto, Inventory>();

            CreateMap<UserModel,IdentityUser>();
        }
    }
}
