using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Context;
using InventoryAPI.Model;
using AutoMapper;
using InventoryAPI.Services.ProductServices;
using InventoryAPI.Services.InventoryService;
using InventoryAPI.DTO.InventoryDto;
using InventoryAPI.DTO;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class InventoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetInventories()
        {


            try
            {
                var inventory = await _inventoryService.GetInventories();
                var resources = _mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryDto>>(inventory);

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

        // GET: api/Inventory/5
        [HttpGet("{id:int}", Name = "GetInventory")]
        public async Task<ActionResult<InventoryDto>> GetInventory(int id)
        {
            try
            {
                var inventory = await _inventoryService.GetInventory(id);
                var resources = _mapper.Map<Inventory, InventoryDto>(inventory);

                if (resources == null)
                {
                    return NotFound("Não existem registros com esse Id.");
                }

                return Ok(resources);

            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("inventorybyname")]
        public async Task<ActionResult<IAsyncEnumerable<Inventory>>> GetInventoryByName([FromQuery] string name)
        {
            try
            {
                var inventory = await _inventoryService.GetInventoryByName(name);
                var resources = _mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryDto>>(inventory);
                if (resources == null)
                {
                    return NotFound("Não existem registros com esse nome.");
                }

                return Ok(resources);

            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        // PUT: api/Inventory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, InventoryDto inventoryDto)
        {
            try
            {
                var inventory = _mapper.Map<InventoryDto, Inventory>(inventoryDto);

                if (inventory.Id == id)
                {
                    await _inventoryService.UpdateInventory(inventory);
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

        // POST: api/Inventory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventory(CreateInventoryDto createInventoryDto)
        {
            try
            {
                var inventory = _mapper.Map<CreateInventoryDto, Inventory>(createInventoryDto);

                await _inventoryService.CreateInventory(inventory);

                return CreatedAtRoute(nameof(GetInventory), new { id = inventory.Id }, inventory);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            try
            {
                var inventory = await _inventoryService.GetInventory(id);

                if (inventory != null)
                {
                    await _inventoryService.DeleteInventory(inventory);
                    return Ok($"Produto com id={id} deletado com sucesso!");
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
