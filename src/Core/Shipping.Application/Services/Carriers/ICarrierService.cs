using Shipping.Application.DTOs.Carriers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Application.Services.Carriers;

public interface ICarrierService
{
    Task<IEnumerable<CarrierDto>> GetAllCarriersAsync();
    Task<string> AddCarrierAsync(AddCarrierDto addCarrierDto);
    Task<string> UpdateCarrier(UpdateCarrierDto updateCarrierDto);
    Task<string> DeleteCarrierAsync(int carrierId);
}
