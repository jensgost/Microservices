using Microsoft.AspNetCore.Mvc;
using StockService.Data;
using StockService.Models.Domain;
using StockService.Models.DTO;

namespace StockService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public StockController(StockServiceContext context)
        {
            Context = context;
        }
        private StockServiceContext Context { get; }

        [HttpPut("{articleNumber}")]
        public IActionResult UpdateStockLevel(string articleNumber, UpdateStockLevelDto updateStockLevelDto)
        {
            var stockLevel = Context.StockLevel
                .FirstOrDefault(y => y.ArticleNumber == updateStockLevelDto.ArticleNumber);
            
            if (stockLevel == null)
            {
                stockLevel = new StockLevel(
                    updateStockLevelDto.ArticleNumber,
                    updateStockLevelDto.StockLevel
               );

                Context.StockLevel.Add(stockLevel);
            }
            else
            {
                stockLevel.Stock = updateStockLevelDto.StockLevel;
            }

            Context.SaveChanges();

            return NoContent(); // 204 No Content
        }

        [HttpGet]
        public IEnumerable<StockLevelDto> GetAll()
        {
            var stockLevelDtos = Context.StockLevel.Select(y => new StockLevelDto
            {
                ArticleNumber = y.ArticleNumber,
                Stock = y.Stock
            });

            return stockLevelDtos;
        }
    }

    public class StockLevelDto
    {
        public string ArticleNumber { get; set; }
        public int Stock { get; set; }
    }
}
