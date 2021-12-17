using Microsoft.EntityFrameworkCore;
using CatalogService.Models.Product;

namespace CatalogService.Data
{
    public class CatalogServiceContext : DbContext
    {
        public DbSet<CatalogProduct> Products { get; set; }
        public CatalogServiceContext(DbContextOptions<CatalogServiceContext> options)
            : base(options)
        {

        }
    }
}
