using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace InventoryAPI.Model
{
    public class ProductType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; } = new Collection<Product>();
    }
}