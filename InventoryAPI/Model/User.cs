using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string FullName { get; set; }
        [Required]
        [Phone]
        [StringLength(11)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; } = false;

    }
}
