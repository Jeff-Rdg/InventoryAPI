using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO.UserDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
