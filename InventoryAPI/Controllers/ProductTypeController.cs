using AutoMapper;
using InventoryAPI.DTO.ProductTypeDto;
using InventoryAPI.Model;
using InventoryAPI.Services.ProductTypeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
                var resources = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeDTO>>(productTypes);

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

        [HttpGet("producttypebyname")]
        public async Task<ActionResult<IAsyncEnumerable<ProductType>>> GetProductTypeByName([FromQuery] string name)
        {
            try
            {
                var productTypes = await _productTypesService.GetProductTypeByName(name);
                var resources = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeDTO>>(productTypes);

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
                var resource = _mapper.Map<ProductType, ProductTypeDTO>(productType);

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
        public async Task<IActionResult> CreateProductType(ProductTypeDTO resource)
        {

            try
            {
                int count = 0;
                var productType = _mapper.Map<ProductTypeDTO, ProductType>(resource);
                var searchProductType = await _productTypesService.GetProductTypeByName(productType.Name);

                foreach (var item in searchProductType)
                {
                    if(item.Name.ToLower() == productType.Name.ToLower())
                    {
                        count++;
                    }
                }

                if(count == 0)
                {
                    await _productTypesService.CreateProductType(productType);

                    return CreatedAtRoute(nameof(GetProductType), new { id = productType.Id }, resource);

                }

                return BadRequest("Categoria já registrada");

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProductType(int id, [FromBody] ProductTypeDTO resource)
        {
            try
            {
                var productType = _mapper.Map<ProductTypeDTO, ProductType>(resource);

                if (productType.Id == id)
                {
                    await _productTypesService.UpdateProductType(productType);
                    return Ok($"Tipo de produto com id={id} atualizado com sucesso!");
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
                    return Ok($"Tipo de Produto com id={id} deletado com sucesso!");
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
