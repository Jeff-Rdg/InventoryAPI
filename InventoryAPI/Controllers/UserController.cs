using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.UserDto;
using InventoryAPI.Model;
using InventoryAPI.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                // chamo o método que retorna todos os usuários cadastrados no banco de dados
                // esse método retorna os usuários com a Model User, onde possuem dados que não quero que retornem para o usuário
                var users = await _userService.GetUsers();

                // faço o mapeamento de 'users' para obter o retorno do tipo 'UserDto', onde não possuem todas as propriedades de 'User'
                var userDto = _mapper.Map<IEnumerable<UserDto>>(users);

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(userDto);

            }
            catch
            {
                return BadRequest("Invalido");

            }
        }


    }
}
