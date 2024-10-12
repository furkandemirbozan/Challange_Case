using Shipping.Application.DTOs.CarrierConfigurations;
using Shipping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Application.Services.CarrierConfigurations;

public interface ICarrierConfigurationsService
{
    Task<IEnumerable<CarrierConfigurationsDto>> GetAllCarrierConfigurationsAsync();
    Task<string> AddCarrierConfigurationAsync(AddCarrierConfigurationsDto addCarrierConfigurationsDto);
    Task<string> UpdateCarrierConfigurationAsync(UpdateCarrierConfigurationDto configuration);
    Task<string> DeleteCarrierConfigurationAsync(int configurationId);
}
