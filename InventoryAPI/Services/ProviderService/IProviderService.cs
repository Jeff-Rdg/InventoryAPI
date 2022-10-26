using InventoryAPI.Model;

namespace InventoryAPI.Services.ProviderService
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetProviders();
        Task<Provider> GetProvider(int id);
        Task<IEnumerable<Provider>> GetProviderByName(string name);
        Task CreateProvider(Provider provider);
        Task UpdateProvider(Provider provider);
        Task DeleteProvider(Provider provider);
    }
}
