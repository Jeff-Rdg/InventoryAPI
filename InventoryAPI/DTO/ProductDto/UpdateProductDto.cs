using InventoryAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public int ProductTypeId { get; set; }
    }
}
