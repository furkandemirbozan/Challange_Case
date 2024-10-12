using AutoMapper;
using Shipping.Application.DTOs.CarrierConfigurations;
using Shipping.Application.DTOs.Carriers;
using Shipping.Application.DTOs.Orders;
using Shipping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Carrier, CarrierDto>();
        CreateMap<AddCarrierDto, Carrier>();
        CreateMap<UpdateCarrierDto, Carrier>();


        CreateMap<CarrierConfiguration, CarrierConfigurationsDto>();
        CreateMap<AddCarrierConfigurationsDto, CarrierConfiguration>();
        CreateMap<UpdateCarrierConfigurationDto, CarrierConfiguration>();


        CreateMap<Order, OrderDto>();
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.OrderDesi, opt => opt.MapFrom(src => src.Desi));
    }
}
