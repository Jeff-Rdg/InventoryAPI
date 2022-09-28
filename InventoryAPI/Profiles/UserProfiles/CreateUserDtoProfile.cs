using AutoMapper;
using InventoryAPI.DTO.UserDto;
using InventoryAPI.Model;

namespace InventoryAPI.Profiles.UserProfiles
{
    public class CreateUserDtoProfile : Profile
    {
        public CreateUserDtoProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
