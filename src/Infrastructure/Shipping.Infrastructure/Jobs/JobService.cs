using Shipping.Application.Jobs;
using Shipping.Application.Repositories;
using Shipping.Domain.Entities;
using Shipping.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Infrastructure.Jobs;

public class JobService : IJobService
{
    private readonly IBaseRepository<CarrierReport> _carrierReportRepository;
    private readonly IBaseRepository<Order> _orderRepository;

    public JobService(IBaseRepository<CarrierReport> carrierReportRepository, IBaseRepository<Order> orderRepository)
    {
        _carrierReportRepository = carrierReportRepository;
        _orderRepository = orderRepository;
    }

    public async Task GenerateCarrierReports()
    {
        // Siparişleri kargo ve sipariş tarihi bazında grupla
        var orders = _orderRepository.GetAllAsync();
        var groupedOrders = _orderRepository.GetQuery()
            .GroupBy(o => new { o.CarrierId, OrderDate = o.OrderDate.Date })
            .Select(group => new
            {
                CarrierId = group.Key.CarrierId,
                OrderDate = group.Key.OrderDate,
                TotalCarrierCost = group.Sum(o => o.OrderCarrierCost)
            })
            .ToList();

        // CarrierReports tablosuna kayıt ekle
        foreach (var order in groupedOrders)
        {
            var carrierReport = new CarrierReport
            {
                CarrierId = order.CarrierId,
                CarrierReportDate = order.OrderDate,
                CarrierCost = order.TotalCarrierCost
            };
            await _carrierReportRepository.AddAsync(carrierReport);
        }

    }
}
