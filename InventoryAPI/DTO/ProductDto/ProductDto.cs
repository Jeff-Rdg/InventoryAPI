using InventoryAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public ProductType ProductType { get; set; }

    }
}
