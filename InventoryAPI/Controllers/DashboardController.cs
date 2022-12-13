using InventoryAPI.Services.AuthenticateService;
using InventoryAPI.Services.InventoryService;
using InventoryAPI.Services.ProductServices;
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
    public class DashboardController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IAuthenticate _authenticate;
        private readonly IProviderService _providerService;

        public DashboardController(IProductService productService, IInventoryService inventoryService, IAuthenticate authenticate, IProviderService providerService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _authenticate = authenticate;
            _providerService = providerService;
        }

        [HttpGet("products")]
        public async Task<ActionResult<int>> CountProducts()
        {
            try
            {
                var products = await _productService.GetProducts();

                var quantity = products.Count();

                return Ok(quantity);

            }
            catch
            {

                throw;
            }
        }

        [HttpGet("inventory")]
        public async Task<ActionResult<int>> CountInventory()
        {
            try
            {
                var products = await _inventoryService.GetInventories();
                int count = 0;
                foreach (var product in products)
                {
                    if (product.Quantity > 0)
                    {
                        count += product.Quantity;
                    }
                }

                return Ok(count);

            }
            catch
            {

                throw;
            }
        }

        [HttpGet("valueinventory")]
        public async Task<ActionResult<decimal>> ValueInventory()
        {
            try
            {
                var products = await _inventoryService.GetInventories();
                decimal count = 0;
                foreach (var product in products)
                {
                    if (product.Quantity > 0 && product.TotalValue > 0)
                    {
                        count += product.TotalValue;
                    }
                }

                return Ok(count);

            }
            catch
            {

                throw;
            }
        }

        [HttpGet("users")]
        public async Task<ActionResult<int>> Users()
        {
            try
            {
                var users = await _authenticate.GetUsers();
                var count = users.Count();

                return Ok(count);

            }
            catch
            {

                throw;
            }
        }

        [HttpGet("providers")]
        public async Task<ActionResult<int>> Providers()
        {
            try
            {
                var providers = await _providerService.GetProviders();
                var count = providers.Count();

                return Ok(count);

            }
            catch
            {

                throw;
            }
        }
    }
}
