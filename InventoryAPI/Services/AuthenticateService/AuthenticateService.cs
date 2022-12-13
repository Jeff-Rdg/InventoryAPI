using InventoryAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services.AuthenticateService
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticateService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string userName, string email, string password)
        {
            var appUser = new IdentityUser
            {
                UserName = userName,
                Email = email,
            };

            var result = await _userManager.CreateAsync(appUser, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, isPersistent: false);
            }
            return result.Succeeded;
        }
        public async Task<IEnumerable<IdentityUser>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

    }
}
