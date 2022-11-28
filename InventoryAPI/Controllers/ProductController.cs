using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.Model;
using InventoryAPI.Services.ProductServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();

                var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

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
        public async Task<ActionResult<IAsyncEnumerable<ProductDto>>> GetProductByName([FromQuery] string name)
        {
            try
            {
                var products = await _productService.GetProductByName(name);

                var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

                if (resources == null)
                {
                    return NotFound("Não existem registros com o nome informado");
                }
                return Ok(resources);
                //return Ok(products);
            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);
                var resources = _mapper.Map<Product, ProductDto>(product);

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
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {

            try
            {
                var productModel = _mapper.Map<CreateProductDto, Product>(createProductDto);

                await _productService.CreateProduct(productModel);

                var resources = _mapper.Map<Product, ProductDto>(productModel);
                //var productDto = _mapper.Map<ProductDto>(productModel);
                return CreatedAtRoute(nameof(GetProduct), new { id = resources.Id }, productModel);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task <ActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            try
            {
                var updateProduct = _mapper.Map<UpdateProductDto, Product>(productDto);

                if (updateProduct.Id == id)
                {
                    await _productService.UpdateProduct(updateProduct);
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
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var getProduct = await _productService.GetProduct(id);

                if (getProduct != null)
                {
                    await _productService.DeleteProduct(getProduct);
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
