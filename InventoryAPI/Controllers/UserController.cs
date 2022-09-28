using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.UserDto;
using InventoryAPI.Model;
using InventoryAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;


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

                // faço o mapeamento de 'users' do tipo 'User' para obter o retorno em 'userDto' do tipo 'UserDto', onde não possuem todas as propriedades de 'User'
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
        [HttpGet("userbyname")]
        public async Task <ActionResult<IEnumerable<UserDto>>> GetUserByName([FromQuery] string name)
        {
            try
            {
                var users = await _userService.GetUserByName(name);

                var usersDTO = _mapper.Map<IEnumerable<UserDto>>(users);

                if (users.Count() == 0)
                {
                    return NotFound("Não existem registros com o nome informado");
                }
                return Ok(usersDTO);

            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);

                var userDTO = _mapper.Map<UserDto>(user);

                if (user == null)
                {
                    return NotFound("Não existe produto com este Id.");
                }
                return Ok(userDTO);
            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
        {

            try
            {
                var userModel = _mapper.Map<User>(createUserDto);

                await _userService.CreateUser(userModel);

                var userDto = _mapper.Map<UserDto>(userModel);
                return CreatedAtRoute(nameof(GetUser), new { id = userDto.Id }, userDto);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            try
            {
                var updateUser = _mapper.Map<User>(userDto);

                if (updateUser.Id == id)
                {
                    await _userService.UpdateUser(updateUser);
                    return Ok($"Usuário com id={id} atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {
                return BadRequest("Operação Invalida");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var getUser = await _userService.GetUser(id);


                if (getUser.Id != null)
                {
                    await _userService.DeleteUser(getUser);
                    return Ok($"Usuário com id={id} deletado com sucesso!");
                }
                else
                {
                    return NotFound("Produto não encontrado");
                }
            }
            catch
            {
                return BadRequest("Operação Invalida");
            }
        }
    }
}
