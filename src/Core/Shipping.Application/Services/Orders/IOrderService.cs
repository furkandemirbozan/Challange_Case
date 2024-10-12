using Shipping.Application.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Application.Services.Orders;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task AddOrderAsync(CreateOrderDto orderDto);
    Task RemoveOrderAsync(int orderId);
}
