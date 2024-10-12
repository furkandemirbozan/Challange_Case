using Microsoft.EntityFrameworkCore;
using Shipping.Domain.Entities;
using Shipping.Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Persistence.Context;

public class ShippingDbContext : DbContext
{
    public ShippingDbContext(DbContextOptions<ShippingDbContext> options) : base(options)
    {

    }

    public DbSet<Carrier> Carriers { get; set; }
    public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CarrierReport> CarrierReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //bu assembly Yani persistence içerisindeki  bütün configurationları algılar 
        //Çünkü hepsi IEntityTypeConfiguration interface'ini implemente ettiği için 


        //Assembly eklemeseydik tek tek ekleyecektik
        //modelBuilder.ApplyConfiguration(new CarrierEntityConfiguration());
        //modelBuilder.ApplyConfiguration(new CarrierConfigurationEntityConfiguration());
        //modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
