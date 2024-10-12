using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Shipping.Application.Jobs;
using Shipping.Application.Mapping;
using Shipping.Application.Repositories;
using Shipping.Application.Services.CarrierConfigurations;
using Shipping.Application.Services.Carriers;
using Shipping.Application.Services.Orders;
using Shipping.Domain.Entities;
using Shipping.Infrastructure.Jobs;
using Shipping.Infrastructure.Services.CarrierConfigurations;
using Shipping.Infrastructure.Services.Carriers;
using Shipping.Infrastructure.Services.Orders;
using Shipping.Persistence.Context;
using Shipping.Persistence.Repositories.Base;

namespace Shipping.API.Extensions;

public static class ServiceRegistration
{
    public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Persistence servisleri
        services.AddDbContext<ShippingDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        //Repository servisleri
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        //Application Servisleri
        services.AddScoped<ICarrierService,CarrierService>();
        services.AddScoped<ICarrierConfigurationsService, CarrierConfigurationsService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IJobService, JobService>();

        services.AddAutoMapper(typeof(MappingProfile));

        //API servisleri
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //hangfire

        services.AddHangfire(config =>
        {
            config.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions()
            {
                SchemaName = "Shipping.Hf",
                PrepareSchemaIfNecessary = true
            });
        });
        
        services.AddHangfireServer();

    }
}
