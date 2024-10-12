using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Domain.Entities.Base;

namespace Shipping.Domain.Entities;

public class Order : BaseEntity
{
    public int CarrierId { get; set; } 

    /// <summary>
    /// Siparişin desi miktarı
    /// </summary>
    public int OrderDesi { get; set; } 

    /// <summary>
    ///  Sipariş tarihi
    /// </summary>
    public DateTime OrderDate { get; set; } = DateTime.Now; 

    /// <summary>
    /// // Kargo ücreti
    /// </summary>
    public decimal OrderCarrierCost { get; set; } 

    public Carrier Carrier { get; set; }
}
