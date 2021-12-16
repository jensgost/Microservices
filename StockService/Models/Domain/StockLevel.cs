using System.ComponentModel.DataAnnotations;

namespace StockService.Models.Domain
    
{
    public class StockLevel
    {
        public StockLevel(string articleNumber, int stock)
        {
            ArticleNumber = articleNumber;
            Stock = stock;
        }

        [Key] // för att manuellt sätta detta som primary key
        public string ArticleNumber { get; set; }
        public int Stock { get; set; }

    }
}
