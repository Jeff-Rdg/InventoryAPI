using InventoryAPI.Context;
using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services.StorageService
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _context;

        public StorageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Storage>> GetStorages()
        {
            try
            {
                return await _context.Storages.ToListAsync();
            }
            catch 
            {

                throw;
            }
        }
        public async Task<IEnumerable<Storage>> GetStorageByName(string name)
        {
            try
            {
                IEnumerable<Storage> storages;
                if (string.IsNullOrWhiteSpace(name))
                {
                    storages = await _context.Storages.Where(x => x.Name.Contains(name)).ToListAsync();
                }
                else
                {
                    storages = await GetStorages();
                }
                return storages;
            }
            catch
            {

                throw;
            }
        }

        public async Task<Storage> GetStorage(int id)
        {
            try
            {
                var storage = await _context.Storages.FindAsync(id);
                return storage;
            }
            catch
            {

                throw;
            }
        }


        public async Task CreateStorage(Storage storage)
        {
            try
            {
                _context.Storages.Add(storage);
                await _context.SaveChangesAsync();
            }
            catch
            {

                throw;
            }
        }

        public async Task UpdateStorage(Storage storage)
        {
            _context.Entry(storage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStorage(Storage storage)
        {
            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();
        }
    }
}
