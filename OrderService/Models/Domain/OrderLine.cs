namespace OrderService.Models.Domain
{
    public class OrderLine
    {
        public OrderLine(int orderLineId, int quantity)
        {
            OrderLineId = orderLineId;
            Quantity = quantity;
        }

        public int OrderLineId { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }   
    }
}
