using AutoMapper;
using InventoryAPI.DTO;
using InventoryAPI.Model;
using InventoryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IProductService _productService;

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

                var productsDTO = _mapper.Map<IEnumerable<ProductDto>>(products);

                if (products == null)
                {
                    return NotFound();
                }

                return Ok(productsDTO);

                //return Ok(products);
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

                var productsDTO = _mapper.Map<IEnumerable<ProductDto>>(products);

                if (products.Count() == 0)
                {
                    return NotFound("Não existem registros com o nome informado");
                }
                return Ok(productsDTO);
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

                var productDTO = _mapper.Map<ProductDto>(product);

                if (product == null)
                {
                    return NotFound("Não existe produto com este Id.");
                }
                return Ok(productDTO);
            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto createProductDto)
        {
            // Continuar aqui a quebrar a cabeça
            try
            {
                var productModel = _mapper.Map<Product>(createProductDto);

                await _productService.CreateProduct(productModel);

                var productDto = _mapper.Map<ProductDto>(productModel);
                return CreatedAtRoute(nameof(GetProduct), new { id = productDto.Id }, productDto);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }
    }
}
