using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

    }
}
