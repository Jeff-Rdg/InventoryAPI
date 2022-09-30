using AutoMapper;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.Model;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductTypeService _productTypesService;

        public ProductTypeController(IProductTypeService productTypesService, IMapper mapper)
        {
            _productTypesService = productTypesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ProductType>>> GetProductTypes()
        {
            try
            {
                var productTypes = await _productTypesService.GetProductTypes();
                var resources = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeDto>> (productTypes);

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

        [HttpGet("productbyname")]
        public async Task<ActionResult<IAsyncEnumerable<ProductType>>> GetProductTypeByName([FromQuery] string name)
        {
            try
            {
                var productTypes = await _productTypesService.GetProductTypeByName(name);
                var resources = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeDto>>(productTypes);

                if (resources.Count() == 0)
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

        [HttpGet("{id:int}", Name = "GetProductType")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            try
            {
                var productType = await _productTypesService.GetProductType(id);
                var resource = _mapper.Map<ProductType, ProductTypeDto>(productType);

                //var productDTO = _mapper.Map<ProductDto>(product);

                if (resource == null)
                {
                    return NotFound("Não existe produto com este Id.");
                }
                return Ok(resource);
            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductType([FromBody] CreateProductTypeDto resource)
        {

            try
            {

                var productType = _mapper.Map<CreateProductTypeDto, ProductType>(resource);

                await _productTypesService.CreateProductType(productType);

                return CreatedAtRoute(nameof(GetProductType), new { id = productType.Id }, resource);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProductType(int id, [FromBody] ProductTypeDto resource)
        {
            try
            {
                var productType = _mapper.Map<ProductTypeDto, ProductType>(resource);

                if (productType.Id == id)
                {
                    await _productTypesService.UpdateProductType(productType);
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
        public async Task<ActionResult> DeleteProductType(int id)
        {
            try
            {
                var productType = await _productTypesService.GetProductType(id);

                if (productType != null)
                {
                    await _productTypesService.DeleteProductType(productType);
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
