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
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();

                List<ProductDTO> productsReturn = new List<ProductDTO>();

                foreach (var product in products)
                {
                    productsReturn.Add(new ProductDTO { Id = product.Id, Name = product.Name, Description = product.Description, ProductTypeId = product.ProductTypeId, CreatedDate = product.CreatedDate});
                }
                
                return Ok(productsReturn);
                
                //return Ok(products);
            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("productbyname")]
        public async Task<ActionResult<IAsyncEnumerable<Product>>> GetProductByName([FromQuery] string name)
        {
            try
            {
                var products = await _productService.GetProductByName(name);

                List<ProductDTO> productsReturn = new List<ProductDTO>();

                foreach (var product in products)
                {
                    productsReturn.Add(new ProductDTO { Id = product.Id, Name = product.Name, Description = product.Description, ProductTypeId = product.ProductTypeId, CreatedDate = product.CreatedDate });
                }


                if (productsReturn == null)
                {
                    return NotFound("Não existem registros com o nome informado");
                }
                return Ok(productsReturn);
                //return Ok(products);
            }
            catch
            {
                return BadRequest("Invalido");

            }
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);

                ProductDTO pr = new ProductDTO(){
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ProductTypeId = product.ProductTypeId,
                    CreatedDate = product.CreatedDate,
                };

                if (product == null)
                {
                    return NotFound("Não existe produto com este Id.");
                }
                return Ok(pr);
            }
            catch
            {
                return BadRequest("Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            // Continuar aqui a quebrar a cabeça
            try
            {

                ProductDTO newProduct = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ProductTypeId = product.ProductTypeId,
                    CreatedDate = product.CreatedDate
                };

                await _productService.CreateProduct(product);
                return CreatedAtRoute(nameof(GetProduct), new { id = product.Id }, newProduct);

            }
            catch
            {
                return BadRequest("Invalido");
            }
        }
    }
}
