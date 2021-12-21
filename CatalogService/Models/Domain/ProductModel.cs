using System.ComponentModel.DataAnnotations;

namespace CatalogService.Models.Domain
{
    public class ProductModel
    {
        public ProductModel(int id, string name, string description, string imageUrl, double price, string articleNumber /*string urlSlug*/)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            ArticleNumber = articleNumber;  
            //UrlSlug = urlSlug;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string ArticleNumber { get; set; }
        //public string UrlSlug { get; set; }
    }
}
