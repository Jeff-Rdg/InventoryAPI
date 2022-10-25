using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Model
{
    public class Storage
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
