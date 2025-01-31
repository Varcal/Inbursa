using Inbursa.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Inbursa.Infra.Data.Mappings
{
    public class PaymentFlowSummaryMapping : IEntityTypeConfiguration<PaymentFlowSummary>
    {
        public void Configure(EntityTypeBuilder<PaymentFlowSummary> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.MonthlyPayment).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalInterest).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalPayment).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasMany(p => p.PaymentSchedule)
                   .WithOne()
                   .HasForeignKey(p => p.PaymentFlowSummaryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
