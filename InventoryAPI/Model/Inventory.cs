using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public int Quantity { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public decimal UnitValue { get; set; }
        [NotMapped]
        public decimal TotalValue { get => this.Quantity * this.UnitValue; }
    }
}
