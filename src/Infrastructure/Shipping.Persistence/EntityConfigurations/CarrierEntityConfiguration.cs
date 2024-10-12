using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping.Domain.Entities;
using Shipping.Persistence.EntityConfigurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Persistence.EntityConfigurations;

public class CarrierEntityConfiguration: BaseEntityEntityConfiguration<Carrier>
{
    public override void Configure(EntityTypeBuilder<Carrier> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.CarrierName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.CarrierPlusDesiCost)
            .IsRequired();

    }

}
