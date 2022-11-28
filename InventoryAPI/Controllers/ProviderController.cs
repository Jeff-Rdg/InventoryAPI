using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.DTO.ProviderDto;
using InventoryAPI.Model;
using InventoryAPI.Services.ProviderService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProviderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProviderService _providerService;

        public ProviderController(IMapper mapper, IProviderService providerService)
        {
            _mapper = mapper;
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Provider>>> GetProviders()
        {
            try
            {
                var providers = await _providerService.GetProviders();

                if (providers == null)
                {
                    return NotFound();
                }

                return Ok(providers);

            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("providerbyname")]
        public async Task<ActionResult<IAsyncEnumerable<Provider>>> GetProviderByName([FromQuery] string name)
        {
            try
            {
                var providers = await _providerService.GetProviderByName(name);

                if (providers.Count() == 0)
                {
                    return NotFound("Não existem registros com o nome informado");
                }
                return Ok(providers);
            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("{id:int}", Name = "GetProvider")]
        public async Task<ActionResult<Provider>> GetProvider(int id)
        {
            try
            {
                var provider = await _providerService.GetProvider(id);

                if (provider == null)
                {
                    return NotFound("Não existe Fornecedor com este Id.");
                }
                return Ok(provider);
            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Provider>> CreateProvider(CreateProviderDto createProviderDto)
        {

            try
            {
                var providerModel = _mapper.Map<CreateProviderDto, Provider>(createProviderDto);

                await _providerService.CreateProvider(providerModel);

                return CreatedAtRoute(nameof(GetProvider), new { id = providerModel.Id }, providerModel);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProvider(int id, [FromBody] Provider provider)
        {
            try
            {

                if (provider.Id == id)
                {
                    await _providerService.UpdateProvider(provider);
                    return Ok($"Produto com id={id} atualizado com sucesso!");
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
        public async Task<ActionResult> DeleteProvider(int id)
        {
            try
            {
                var getProvider = await _providerService.GetProvider(id);

                if (getProvider != null)
                {
                    await _providerService.DeleteProvider(getProvider);
                    return Ok($"Fornecedor com id={id} deletado com sucesso!");
                }
                else
                {
                    return NotFound("Fornecedor não encontrado");
                }
            }
            catch
            {
                return BadRequest("Operação Invalida");
            }
        }
    }
}
