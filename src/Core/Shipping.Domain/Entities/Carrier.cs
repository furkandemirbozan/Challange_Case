using Shipping.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Domain.Entities;

public class Carrier : BaseEntity
{
    /// <summary>
    /// Kargo Şirket İsmi
    /// </summary>
    public string CarrierName { get; set; }
    /// <summary>
    /// +1 desi ücreti
    /// </summary>
    public int CarrierPlusDesiCost { get; set; }
    
    public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; }
}
