using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO.StorageDto
{
    public class CreateStorageDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
