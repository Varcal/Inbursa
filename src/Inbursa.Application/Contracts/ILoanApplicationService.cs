using Inbursa.Domain.Dtos.Requests;
using Inbursa.Domain.Dtos.Responses;


namespace Inbursa.Application.Contracts
{
    public interface ILoanApplicationService
    {
        Task<(bool IsValid, List<string> Errors, PaymentFlowSummaryResponseDto Result)> SimulateLoanAsync(ProposalRequestDto proposalRequestDto);
    }
}
