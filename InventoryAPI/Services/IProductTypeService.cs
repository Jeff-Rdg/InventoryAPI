using InventoryAPI.Model;

namespace InventoryAPI.Services
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetProductTypes();
        Task<ProductType> GetProductType(int id);
        Task<IEnumerable<ProductType>> GetProductTypeByName(string name);
        Task CreateProductType(ProductType productType);
        Task UpdateProductType(ProductType productType);
        Task DeleteProductType(ProductType productType);
    }
}
