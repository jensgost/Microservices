using Microsoft.EntityFrameworkCore;
using CatalogService.Models.Domain;

namespace CatalogService.Data
{
    public class CatalogServiceContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public CatalogServiceContext(DbContextOptions<CatalogServiceContext> options)
            : base(options)
        {
        }


        // seed data
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogProduct>().HasData(
                new CatalogProduct
                {
                    Id = 1,
                    Name = "Navy Pants",
                    Description = "Cotton pants in slim model",
                    ImageUrl = "https://img01.ztat.net/article/spp-media-p1/71e0cbd7c4d64970850cfc4c1a960d94/0bd9f5a2e941494f815cb63f2e2f66cb.jpg?imwidth=1800&filter=packshot",
                    Price = 899,
                    ArticleNumber = "PM001",
                    UrlSlug = "navy-pants"
                }
            ); 
        }*/
    }
}
