using InventoryAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace InventoryAPI.Services.AuthenticateService
{
    public interface IAuthenticate
    {
        Task<IEnumerable<IdentityUser>> GetUsers();
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string userName, string email, string password);
        Task Logout();

    }
}
