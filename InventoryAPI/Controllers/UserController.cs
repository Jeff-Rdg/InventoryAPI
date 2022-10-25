using AutoMapper;
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
                var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                if (resources == null)
                {
                    return NotFound();
                }

                return Ok(resources);

            }
            catch
            {
                return BadRequest("Invalido");

            }
        }
        [HttpGet("userbyname")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserByName([FromQuery] string name)
        {
            try
            {
                var users = await _userService.GetUserByName(name);

                var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);

                if (resources == null)
                {
                    return NotFound("Não existem registros com o nome informado");
                }
                return Ok(resources);

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

                var resources = _mapper.Map<User, UserDto>(user);

                if (resources == null)
                {
                    return NotFound("Não existe produto com este Id.");
                }
                return Ok(resources);
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

                if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var emailCheck = await _userService.GetUserByEmail(createUserDto.Email);

                if (emailCheck != null)
                {
                    return BadRequest("Email ja cadastrado no sistema.");
                }
                else
                {
                    var userModel = _mapper.Map<CreateUserDto, User>(createUserDto);
                    await _userService.CreateUser(userModel);
                    var resources = _mapper.Map<User, UserDto>(userModel);
                    return CreatedAtRoute(nameof(GetUser), new { id = resources.Id }, resources);

                }



            }
            catch
            {
                return BadRequest("Invalido");
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult> LoginUser(LoginUserDto loginUserDto)
        {

            try
            {
                //corrigir
                if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var users = await _userService.GetUsers();

                foreach (var user in users)
                {
                    if(user.Email == loginUserDto.Email && user.Password == loginUserDto.Password)
                    {
                        return Ok("Login realizado com sucesso");
                    }
                }
                return BadRequest("Dados informados incorretamente, tente novamente.");

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
                var updateUser = _mapper.Map<UserDto, User>(userDto);

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


                if (getUser != null)
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
