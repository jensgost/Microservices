using BasketService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public BasketController(IDistributedCache cache)
        {
            Cache = cache;
        }
        public IDistributedCache Cache { get; }

        [HttpPut("{basketDto}")]
        public IActionResult CreateBasket(BasketDto basketDto)
        {
            var serializedBasket = JsonSerializer.Serialize(basketDto);

            Cache.SetString(basketDto.Identifier, serializedBasket);

            return NoContent(); // generates 204 no content
        }

        [HttpGet("{basketNumber}")]
        public ActionResult<BasketDto> GetBasket(string basketNumber)
        {

            //hämta value baserat på key
            var serializedBasket = Cache.GetString(basketNumber);

            if (serializedBasket == null)
                return NotFound(); // 404 not found

            // deserialisera värdet från json till objekt
            var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedBasket);

            return Ok(basketDto);
        }
    }
}
