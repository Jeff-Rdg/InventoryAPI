using AutoMapper;
using InventoryAPI.DTO.StorageDto;
using InventoryAPI.Model;
using InventoryAPI.Services.StorageService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StorageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService, IMapper mapper)
        {
            _storageService = storageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Storage>>> GetStorages()
        {
            try
            {
                var storages = await _storageService.GetStorages();

                if (storages == null)
                {
                    return NotFound();
                }

                return Ok(storages);

            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("providerbyname")]
        public async Task<ActionResult<IAsyncEnumerable<Storage>>> GetStorageByName([FromQuery] string name)
        {
            try
            {
                var storages = await _storageService.GetStorageByName(name);

                if (storages == null)
                {
                    return NotFound("Não existem Locais de armazenamento com o nome informado");
                }
                return Ok(storages);
            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("{id:int}", Name = "GetStorage")]
        public async Task<ActionResult<Storage>> GetStorage(int id)
        {
            try
            {
                var storage = await _storageService.GetStorage(id);

                if (storage == null)
                {
                    return NotFound("Não existe Local de armazenamento com este Id.");
                }
                return Ok(storage);
            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Storage>> CreateStorage(CreateStorageDto createStorageDto)
        {

            try
            {
                var storageModel = _mapper.Map<CreateStorageDto, Storage>(createStorageDto);

                await _storageService.CreateStorage(storageModel);

                return CreatedAtRoute(nameof(GetStorage), new { id = storageModel.Id }, storageModel);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateStorage(int id, [FromBody] Storage storage)
        {
            try
            {
                if (storage.Id == id)
                {
                    await _storageService.UpdateStorage(storage);
                    return Ok($"Local de armazenamento com id={id} atualizado com sucesso!");
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
        public async Task<ActionResult> DeleteStorage(int id)
        {
            try
            {
                var storage = await _storageService.GetStorage(id);

                if (storage != null)
                {
                    await _storageService.DeleteStorage(storage);
                    return Ok($"Local de armazenamento com id={id} deletado com sucesso!");
                }
                else
                {
                    return NotFound("Local de armazenamento não encontrado");
                }
            }
            catch
            {
                return BadRequest("Operação Invalida");
            }
        }

    }
}
