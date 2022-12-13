namespace InventoryAPI.DTO.InventoryDto
{
    public class UpdateInventoryDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StorageId { get; set; }
        public int ProviderId { get; set; }
        public int Quantity { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public decimal UnitValue { get; set; }
    }
}
