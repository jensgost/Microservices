using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models.DTO;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        public OrderController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder(OrderDto orderDto)
        {
            var orderJson = new StringContent(
                JsonSerializer.Serialize(orderDto),
                Encoding.UTF8,
                Application.Json);

            var httpClient = httpClientFactory.CreateClient();

            using var httpResponseMessage =
                await httpClient.PostAsync("http://localhost:9000/api/orders", orderJson);

            return Created("", null);
        }
    }
}
