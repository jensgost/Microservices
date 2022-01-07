using System.ComponentModel.DataAnnotations;

namespace OrderService.Models.Domain
{
    public class Order
    {
        [MaxLength(50)]
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
