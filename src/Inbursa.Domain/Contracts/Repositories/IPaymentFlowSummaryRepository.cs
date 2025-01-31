using Inbursa.Domain.Entities;

namespace Inbursa.Domain.Contracts.Repositories
{
    public interface IPaymentFlowSummaryRepository
    {
        Task AddAsync(PaymentFlowSummary summary);
    }
}
