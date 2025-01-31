using Inbursa.Domain.Entities;

namespace Inbursa.Domain.Contracts.Services
{
    public interface ILoanService
    {
        PaymentFlowSummary SimulateLoan(Proposal proposal);
    }
}
