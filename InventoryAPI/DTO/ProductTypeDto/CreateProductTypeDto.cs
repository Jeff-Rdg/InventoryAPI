using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO.ProductTypeDto
{
    public class CreateProductTypeDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
