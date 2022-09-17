using InventoryAPI.Context;
using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
            return await _context.Users.ToListAsync();

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            try
            {

                IEnumerable<User> users;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    users = await _context.Users.Where(u => u.Name.Contains(name)).ToListAsync();

                }
                else
                {
                    users = await GetUsers();
                }
                return users;
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                return user;
            }
            catch
            {

                throw;
            }
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
