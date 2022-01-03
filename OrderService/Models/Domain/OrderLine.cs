namespace OrderService.Models.Domain
{
    public class OrderLine
    {
        public OrderLine(int orderLineId)
        {
            OrderLineId = orderLineId;
        }

        public int OrderLineId { get; set; }
    }
}
