using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Application.DTOs.Carriers;

public class CarrierDto
{
    public int Id { get; set; }
    public string CarrierName { get; set; }
    public int CarrierPlusDesiCost { get; set; }
}
