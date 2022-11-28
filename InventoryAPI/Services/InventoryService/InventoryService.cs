using InventoryAPI.Context;
using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inventory>> GetInventories()

        {
            try
            {
                return await _context.Inventory.Include(p => p.Product).Include(q => q.Provider).Include(r => r.Storage).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Inventory> GetInventory(int id)
        {
            try
            {
                var inventory = await _context.Inventory.Include(p => p.Product).Include(q => q.Provider).Include(r => r.Storage).FirstOrDefaultAsync(i => i.Id == id);
                return inventory;
            }
            catch
            {

                throw;
            }
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByName(string name)
        {
            try
            {
                IEnumerable<Inventory> inventories;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    inventories = await _context.Inventory.Where(n => n.Product.Name.Contains(name)).Include(p => p.Product).Include(q => q.Provider).Include(r => r.Storage).ToListAsync();

                }
                else
                {
                    inventories = await GetInventories();
                }
                return inventories;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateInventory(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInventory(Inventory inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInventory(Inventory inventory)
        {
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
        }



    }
}
