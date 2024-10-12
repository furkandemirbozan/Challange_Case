using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Application.DTOs.Orders;
using Shipping.Application.Services.Orders;

namespace Shipping.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderDto orderDto)
        {
            // Kullanıcıdan gelen orderDto null ise BadRequest döndürülür.
            if (orderDto == null)
            {
                return BadRequest("Invalid order data");
            }

            try
            {
                // OrderService üzerindeki AddOrderAsync metodunu çağırarak yeni sipariş ekleme işlemi yapılır.
                await _orderService.AddOrderAsync(orderDto);
                return Ok("Order successfully added"); // Sipariş ekleme işlemi başarılı ise HTTP 200 (OK) döndürülür.
            }
            catch (ArgumentNullException ex)
            {
                // Eğer herhangi bir null referans hatası oluşursa, spesifik hata mesajı ile birlikte BadRequest döndürülür.
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Eğer belirli bir operasyon geçerli değilse (örneğin uygun kargo firması bulunamadıysa), spesifik hata mesajı döndürülür.
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Eğer başka bir hata oluşursa, genel hata mesajı ile birlikte BadRequest döndürülür.
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/orders/{orderId}
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> RemoveOrder(int orderId)
        {
            try
            {
                // Belirtilen orderId'ye sahip siparişi silmek için OrderService üzerindeki RemoveOrderAsync metodunu çağırıyoruz.
                await _orderService.RemoveOrderAsync(orderId);
                return Ok("Order successfully removed"); // Sipariş başarılı bir şekilde silinirse HTTP 200 (OK) döndürülür.
            }
            catch (KeyNotFoundException ex)
            {
                // Eğer sipariş bulunamazsa, spesifik hata mesajı ile birlikte NotFound döndürülür.
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Eğer başka bir hata oluşursa, genel hata mesajı ile birlikte BadRequest döndürülür.
                return BadRequest(ex.Message);
            }
        }
    }
}

