using Microsoft.EntityFrameworkCore;
using CatalogService.Models.Domain;

namespace CatalogService.Data
{
    public class CatalogServiceContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public object ProductModel { get; internal set; }

        public CatalogServiceContext(DbContextOptions<CatalogServiceContext> options)
            : base(options)
        {
        }
    }
}
