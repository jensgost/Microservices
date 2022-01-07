using Microsoft.EntityFrameworkCore;
using OrderService.Models.Domain;

namespace OrderService.Data
{
    public class OrderServiceContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        {

        }
    }
}
