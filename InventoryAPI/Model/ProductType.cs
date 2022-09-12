using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Model
{
    public class ProductType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}