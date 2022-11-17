using InventoryAPI.Model;

namespace InventoryAPI.Services.InventoryService
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetInventories();
        Task<Inventory> GetInventory(int id);
        Task<IEnumerable<Inventory>> GetInventoryByName(string name);
        Task CreateInventory(Inventory inventory);
        Task UpdateInventory(Inventory inventory);
        Task DeleteInventory(Inventory inventory);
    }
}
