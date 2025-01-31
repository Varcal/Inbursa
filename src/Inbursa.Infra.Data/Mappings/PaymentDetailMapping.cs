using Inbursa.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbursa.Infra.Data.Mappings
{
    public class PaymentDetailMapping : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Month).IsRequired();
            builder.Property(p => p.Principal).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Interest).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Balance).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
