using AutoMapper;
using Shipping.Application.DTOs.Carriers;
using Shipping.Application.Repositories;
using Shipping.Application.Services.Carriers;
using Shipping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Infrastructure.Services.Carriers;

public class CarrierService : ICarrierService
{
    private readonly IBaseRepository<Carrier> _carrierRepository;
    private readonly IMapper _mapper;

    public CarrierService(IBaseRepository<Carrier> carrierRepository, IMapper mapper)
    {
        _carrierRepository = carrierRepository;
        _mapper = mapper;
    }

    public async Task<string> AddCarrierAsync(AddCarrierDto addCarrierDto)
    {
        var carrier = _mapper.Map<Carrier>(addCarrierDto);
        await _carrierRepository.AddAsync(carrier);
        return "Kargo Firması Başarıyla Eklendi";
    }

    public async Task<string> DeleteCarrierAsync(int carrierId)
    {
        var carrier = await _carrierRepository.GetByIdAsync(carrierId);
        if (carrier == null)
        {
            return "Kargo Firması Bulunamadı";
        }
         _carrierRepository.Remove(carrier);
        return "Kargo Firması Başarıyla Silindi";
    }

    public async Task<IEnumerable<CarrierDto>> GetAllCarriersAsync()
    {
        var carriers = await _carrierRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CarrierDto>>(carriers);
    }

    public async Task<string>  UpdateCarrier(UpdateCarrierDto updateCarrierDto)
    {
        var carrier = await _carrierRepository.GetByIdAsync(updateCarrierDto.Id);
        if (carrier == null)
        {
            return "Kargo Firması Bulunamadı";
        }
         carrier =  _mapper.Map(updateCarrierDto,carrier);
        _carrierRepository.Update(carrier);
        return "Kargo Firması Başarıyla Güncellendi";
    }
}
