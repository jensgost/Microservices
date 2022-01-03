using System.ComponentModel.DataAnnotations;

namespace OrderService.Models.Domain
{
    public class Order
    {
        public Order(int orderId, string identifier, string customer)
        {
            OrderId = orderId;
            Identifier = identifier;
            Customer = customer;
        }

        [MaxLength(50)]
        public int OrderId { get; set; }
        public string Identifier { get; set; }
        public string Customer { get; set; }
        public ICollection<OrderLine> Lines { get; set; } = new List<OrderLine>();
    }
}
