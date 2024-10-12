using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Application.DTOs.CarrierConfigurations;
using Shipping.Application.Services.CarrierConfigurations;

namespace Shipping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrierConfigurationsController : ControllerBase
{
    private readonly ICarrierConfigurationsService _carrierConfigurationsService;

    public CarrierConfigurationsController(ICarrierConfigurationsService carrierConfigurationsService)
    {
        _carrierConfigurationsService = carrierConfigurationsService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCarrierConfigurationsAsync()
    {
        var carrierConfigurations = await _carrierConfigurationsService.GetAllCarrierConfigurationsAsync();
        return Ok(carrierConfigurations);
    }
    [HttpPost]
    public async Task<IActionResult> AddCarrierConfigurationAsync(AddCarrierConfigurationsDto addCarrierConfigurationsDto)
    {
        var result = await _carrierConfigurationsService.AddCarrierConfigurationAsync(addCarrierConfigurationsDto);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCarrierConfigurationAsync(UpdateCarrierConfigurationDto updateCarrierConfigurationDto)
    {
        var result = await _carrierConfigurationsService.UpdateCarrierConfigurationAsync(updateCarrierConfigurationDto);
        return Ok(result);
    }
    [HttpDelete("{configurationId}")]
    public async Task<IActionResult> DeleteCarrierConfigurationAsync(int configurationId)
    {
        var result = await _carrierConfigurationsService.DeleteCarrierConfigurationAsync(configurationId);
        return Ok(result);
    }

}
