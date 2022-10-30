namespace InventoryAPI.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public int Quantity { get; set; }
        public bool isDownloaded { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public double UnitValue { get; set; }
    }
}
