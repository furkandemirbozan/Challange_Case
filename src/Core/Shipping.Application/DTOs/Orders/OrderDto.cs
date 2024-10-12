using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Application.DTOs.Orders;

public class OrderDto
{
    public int Id { get; set; }
    public int Desi { get; set; }
    public decimal ShippingPrice { get; set; }
}
