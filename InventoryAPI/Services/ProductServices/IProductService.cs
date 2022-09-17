using InventoryAPI.Model;

namespace InventoryAPI.Services.ProductServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);


    }
}
