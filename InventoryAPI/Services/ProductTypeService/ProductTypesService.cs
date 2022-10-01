using InventoryAPI.Context;
using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services.ProductTypeService
{
    public class ProductTypesService : IProductTypeService
    {

        private readonly AppDbContext _context;

        public ProductTypesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            try
            {
                return await _context.ProductTypes.Include(p=>p.Products).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductType>> GetProductTypeByName(string name)
        {
            try
            {
                IEnumerable<ProductType> productTypes;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    productTypes = await _context.ProductTypes.Where(n => n.Name.Contains(name)).Include(p => p.Products).ToListAsync();

                }
                else
                {
                    productTypes = await GetProductTypes();
                }
                return productTypes;
            }
            catch
            {
                throw;
            }
        }
        public async Task<ProductType> GetProductType(int id)
        {
            try
            {
                var productType = await _context.ProductTypes.FindAsync(id);
                return productType;
            }
            catch
            {

                throw;
            }
        }

        public async Task CreateProductType(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductType(ProductType productType)
        {
            _context.Entry(productType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductType(ProductType productType)
        {
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();
        }
    }
}
