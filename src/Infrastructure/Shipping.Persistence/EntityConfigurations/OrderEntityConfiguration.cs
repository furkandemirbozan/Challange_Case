using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping.Domain.Entities;
using Shipping.Persistence.EntityConfigurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Persistence.EntityConfigurations;

public class OrderEntityConfiguration : BaseEntityEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.OrderDesi)
            .IsRequired();
        builder.Property(x => x.OrderCarrierCost)
            .IsRequired();

    }

}
