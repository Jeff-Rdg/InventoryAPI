using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.DTO.ProviderDto
{
    public class CreateProviderDto
    {
        public string Name { get; set; }
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
