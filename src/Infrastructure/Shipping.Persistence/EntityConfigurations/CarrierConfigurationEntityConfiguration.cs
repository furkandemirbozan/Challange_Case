using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping.Domain.Entities;
using Shipping.Persistence.EntityConfigurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Persistence.EntityConfigurations;

public class CarrierConfigurationEntityConfiguration : BaseEntityEntityConfiguration<CarrierConfiguration>
{
    public override void Configure(EntityTypeBuilder<CarrierConfiguration> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.CarrierMaxDesi)
            .IsRequired();
        builder.Property(x => x.CarrierMinDesi)
            .IsRequired();
        builder.Property(x => x.CarrierCost)
            .IsRequired();
    }

}
