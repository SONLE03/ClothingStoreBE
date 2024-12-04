namespace FurnitureStoreBE.DTOs.Request.OrderRequest
{
    public class OrderItemRequest
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public Guid ColorId { get; set; }
        public long Quantity { get; set; }
    }
}
