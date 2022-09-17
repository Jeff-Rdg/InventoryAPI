using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class UpdateProductDtoProfile : Profile
    {
        public UpdateProductDtoProfile()
        {
            //source => destinations
            CreateMap<ProductDto, Product>();
        }
    }
}
