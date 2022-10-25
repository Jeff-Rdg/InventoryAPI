using InventoryAPI.Model;

namespace InventoryAPI.Services.StorageService
{
    public interface IStorageService
    {
        Task<IEnumerable<Storage>> GetStorages();
        Task<Storage> GetStorage(int id);
        Task<IEnumerable<Storage>> GetStorageByName(string name);
        Task CreateStorage(Storage storage);
        Task UpdateStorage(Storage storage);
        Task DeleteStorage(Storage storage);
    }
}
