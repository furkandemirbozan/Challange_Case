using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Domain.Entities.Base;

namespace Shipping.Domain.Entities;

public class CarrierConfiguration : BaseEntity
{
    public int CarrierId { get; set; }

    /// <summary>
    ///    Minimum desi aralığı
    /// </summary>
    public int CarrierMinDesi { get; set; }
    /// <summary>
    ///     Maksimum desi aralığı
    /// </summary>
    public int CarrierMaxDesi { get; set; }

    /// <summary>
    ///    Bu desi aralığındaki kargo ücreti
    /// </summary>
    public decimal CarrierCost { get; set; } 
    public Carrier Carrier { get; set; } 
}
