namespace OrderService.Models.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Identifier { get; set; }
        public string Customer { get; set; }
        public IEnumerable<OrderLineDto> OrderLine { get; set; }    
    }
}
