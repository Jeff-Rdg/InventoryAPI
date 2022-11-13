﻿using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.DTO.ProviderDto;
using InventoryAPI.DTO.StorageDto;
using InventoryAPI.Model;

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
        }
    }
}
