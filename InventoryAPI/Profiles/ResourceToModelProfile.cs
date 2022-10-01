﻿using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.DTO.UserDto;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateProductTypeDto, ProductType>();
            CreateMap<ProductTypeDto, ProductType>();

            CreateMap<ProductDto, Product>();
            CreateMap<CreateProductDto, Product>();

            CreateMap<CreateUserDto, User>();
        }
    }
}
