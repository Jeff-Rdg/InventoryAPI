using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        [JsonIgnore]
        public ProductType ProductType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
