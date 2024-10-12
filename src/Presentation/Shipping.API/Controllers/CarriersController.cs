using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Application.DTOs.Carriers;
using Shipping.Application.Services.Carriers;

namespace Shipping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarriersController : ControllerBase
{
    private readonly ICarrierService _carrierService;

    public CarriersController(ICarrierService carrierService)
    {
        _carrierService = carrierService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCarriersAsync()
    {
        var carriers = await _carrierService.GetAllCarriersAsync();
        return Ok(carriers);
    }
    [HttpPost]
    public async Task<IActionResult> AddCarrierAsync(AddCarrierDto addCarrierDto)
    {
        var result = await _carrierService.AddCarrierAsync(addCarrierDto);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult>UpdateCarrier(UpdateCarrierDto updateCarrierDto)
    {
        var result = await _carrierService.UpdateCarrier(updateCarrierDto);
        return Ok(result);
    }
    [HttpDelete("{carrierId}")]
    public async Task<IActionResult> DeleteCarrierAsync(int carrierId)
    {
        var result = await _carrierService.DeleteCarrierAsync(carrierId);
        return Ok(result);
    }
}
