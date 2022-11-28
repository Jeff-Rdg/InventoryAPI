using InventoryAPI.Model;

namespace InventoryAPI.DTO.InventoryDto
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Provider Provider { get; set; }
        public int Quantity { get; set; }
        public bool isDownloaded { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public decimal UnitValue { get; set; }
    }
}
