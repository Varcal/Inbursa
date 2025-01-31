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
    public class ProposalMapping : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.LoanAmount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.AnnualInterestRate).IsRequired().HasColumnType("decimal(5,4)");
            builder.Property(p => p.NumberOfMonths).IsRequired();
        }
    }
}
