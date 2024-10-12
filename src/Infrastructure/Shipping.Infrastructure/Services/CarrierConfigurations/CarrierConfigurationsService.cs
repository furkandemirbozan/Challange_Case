using AutoMapper;
using Shipping.Application.DTOs.CarrierConfigurations;
using Shipping.Application.Repositories;
using Shipping.Application.Services.CarrierConfigurations;
using Shipping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Infrastructure.Services.CarrierConfigurations;

public class CarrierConfigurationsService : ICarrierConfigurationsService
{
    private readonly IBaseRepository<CarrierConfiguration> _carrierConfigurationRepository;
    private readonly IMapper _mapper;

    public CarrierConfigurationsService(
        IBaseRepository<CarrierConfiguration> carrierConfigurationRepository, 
        IMapper mapper)
    {
        _carrierConfigurationRepository = carrierConfigurationRepository;
        _mapper = mapper;
    }

    public async Task<string> AddCarrierConfigurationAsync(AddCarrierConfigurationsDto addCarrierConfigurationsDto)
    {
        var carrierConfiguration = _mapper.Map<CarrierConfiguration>(addCarrierConfigurationsDto);
        await _carrierConfigurationRepository.AddAsync(carrierConfiguration);
        return "Kargo Firması Konfigürasyonu Başarıyla Eklendi";
    }

    public async Task<string> DeleteCarrierConfigurationAsync(int configurationId)
    {
        var carrierConfiguration = await _carrierConfigurationRepository.GetByIdAsync(configurationId);
        if (carrierConfiguration == null)
        {
            return "Kargo Firması Konfigürasyonu Bulunamadı";
        }
         _carrierConfigurationRepository.Remove(carrierConfiguration);
        return "Kargo Firması Konfigürasyonu Başarıyla Silindi";

    }

    public async Task<IEnumerable<CarrierConfigurationsDto>> GetAllCarrierConfigurationsAsync()
    {
        var carrierConfigurations = await _carrierConfigurationRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<CarrierConfigurationsDto>>(carrierConfigurations);
    }

    public async Task<string> UpdateCarrierConfigurationAsync(UpdateCarrierConfigurationDto configuration)
    {
        var carrierConfiguration = await _carrierConfigurationRepository.GetByIdAsync(configuration.Id);
        if (carrierConfiguration == null)
        {
            return "Kargo Firması Konfigürasyonu Bulunamadı";
        }
        carrierConfiguration = _mapper.Map(configuration, carrierConfiguration);
        _carrierConfigurationRepository.Update(carrierConfiguration);
        return "Kargo Firması Konfigürasyonu Başarıyla Güncellendi";
    }
}
