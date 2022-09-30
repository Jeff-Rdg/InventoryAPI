using InventoryAPI.Model;
using Microsoft.Build.Framework;

namespace InventoryAPI.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType ProductType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
