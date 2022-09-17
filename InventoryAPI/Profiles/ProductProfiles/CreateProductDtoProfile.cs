using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class CreateProductDtoProfile : Profile
    {
        public CreateProductDtoProfile()
        {
            // source => destinations
            CreateMap<CreateProductDto, Product>();
        }
    }
}
