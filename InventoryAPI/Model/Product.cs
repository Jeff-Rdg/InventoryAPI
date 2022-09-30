using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        [JsonIgnore]
        public virtual ProductType ProductType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
