using InventoryAPI.Context;
using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services.ProviderService
{
    public class ProviderService : IProviderService
    {
        private readonly AppDbContext _context;

        public ProviderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Provider>> GetProviders()
        {
            try
            {
                return await _context.Providers.ToListAsync();

            }
            catch
            {

                throw;
            }
        }


        public async Task<IEnumerable<Provider>> GetProviderByName(string name)
        {
            try
            {
                IEnumerable<Provider> providers;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    providers = await _context.Providers.Where(n => n.Name.Contains(name)).ToListAsync();
                }
                else
                {
                    providers = await GetProviders();
                }
                return providers;
            }
            catch
            {

                throw;
            }
        }
        public async Task<Provider> GetProvider(int id)
        {
            try
            {
                var provider = await _context.Providers.FindAsync(id);
                return provider;
            }
            catch
            {

                throw;
            }
        }


        public async Task CreateProvider(Provider provider)
        {
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProvider(Provider provider)
        {
            _context.Entry(provider).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProvider(Provider provider)
        {
            _context.Providers.Remove(provider);
            await _context.SaveChangesAsync();
        }
    }
}
