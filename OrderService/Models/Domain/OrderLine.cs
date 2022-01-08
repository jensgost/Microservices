namespace OrderService.Models.Domain
{
    public class OrderLine
    {
        public OrderLine(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int OrderLineId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

    }
}
