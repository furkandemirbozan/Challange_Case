using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shipping.Application.DTOs.Orders;
using Shipping.Application.Repositories;
using Shipping.Application.Services.Orders;
using Shipping.Domain.Entities;


namespace Shipping.Infrastructure.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IBaseRepository<Order> _orderRepository;
    private readonly IBaseRepository<Carrier> _carrierRepository;
    private readonly IBaseRepository<CarrierConfiguration> _carrierConfigRepository;
    private readonly IMapper _mapper;

    public OrderService(IBaseRepository<Order> orderRepository,
        IBaseRepository<Carrier> carrierRepository,
        IBaseRepository<CarrierConfiguration> carrierConfigRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _carrierRepository = carrierRepository;
        _carrierConfigRepository = carrierConfigRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }
  
    public async Task AddOrderAsync(CreateOrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        //order.OrderDate = DateTime.Now;

        var carriers = await _carrierRepository.GetQuery()
            .Include(c => c.CarrierConfigurations)
            .ToListAsync();
        if (carriers == null || !carriers.Any())
        {
            throw new Exception("Kargo firmaları bulunamadı");
        }
        var suitableCarriers = carriers.Where(c =>
            c.CarrierConfigurations.Any(cc =>
                cc.CarrierMinDesi <= order.OrderDesi &&
                cc.CarrierMaxDesi >= order.OrderDesi))
            .ToList();

        if (suitableCarriers.Any())
        {

            // En düşük maliyetli kargo firmasını bul ve siparişe ekle 
            var selectedBestConfiguration = suitableCarriers.SelectMany(c => c.CarrierConfigurations).Where(cc =>
                cc.CarrierMinDesi <= order.OrderDesi &&
                cc.CarrierMaxDesi >= order.OrderDesi).OrderBy(x => x.CarrierCost).First();

            // Seçilen kargo firmasının bilgileri siparişe eklenir
            order.CarrierId = selectedBestConfiguration.Carrier.Id;
            order.OrderCarrierCost = selectedBestConfiguration.CarrierCost;
        }
        else
        {
            // En yakın desi aralığına sahip kargo firmasını bul
            var carrierConfigs = await _carrierConfigRepository.GetAllAsync();
            var closestCarrierConfig = carrierConfigs
                .OrderBy(c => Math.Abs(order.OrderDesi - c.CarrierMaxDesi))
                .First();

            // Fiyat hesaplamasını yap
            int desiDifference = order.OrderDesi - closestCarrierConfig.CarrierMaxDesi;

            order.OrderCarrierCost = closestCarrierConfig.CarrierCost + (desiDifference * closestCarrierConfig.Carrier.CarrierPlusDesiCost);

            order.CarrierId = closestCarrierConfig.CarrierId;
        }

        await _orderRepository.AddAsync(order);
        


    }

    public async Task RemoveOrderAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order != null)
        {
            _orderRepository.Remove(order);
        }
    }
}


