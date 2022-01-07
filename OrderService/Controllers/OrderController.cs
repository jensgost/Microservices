using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Models.Domain;
using OrderService.Models.DTO;
using System.Text.Json;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OrderServiceContext _context;

        public OrderController(IHttpClientFactory httpClientFactory, OrderServiceContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> MakeOrder(OrderDto orderDto) // orderDto förväntar sig få info om identifier o customer från POST-anropet
        {
            var httpClient = _httpClientFactory.CreateClient();

            using var httpResponseMessage =
                await httpClient.GetAsync($"http://localhost:7000/api/basket/{orderDto.Identifier}");

            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var basket = JsonSerializer.Deserialize<BasketDto>
                (content, options);

            var createOrder = await _context.Order.AddAsync(new Order()
            {
                Customer = orderDto.Customer,
                OrderLines = basket.BasketItem.Select(y => new OrderLine
                (
                    y.ProductId,
                    y.Quantity
                    )).ToList()
                });

            await _context.SaveChangesAsync();

            return Created("", new OrderLineDto { OrderLineId = createOrder.Entity.OrderId});
        }
    }
}
