using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO.UserDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
