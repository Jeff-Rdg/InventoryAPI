using AutoMapper;
using InventoryAPI.DTO.UserDto;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
