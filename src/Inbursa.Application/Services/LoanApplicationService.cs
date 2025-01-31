using Inbursa.Application.Contracts;
using Inbursa.Domain.Contracts.Repositories;
using Inbursa.Domain.Contracts.Services;
using Inbursa.Domain.Dtos.Requests;
using Inbursa.Domain.Dtos.Responses;
using Inbursa.Domain.Entities;
using Inbursa.Domain.Validators;
using Microsoft.Extensions.Logging;


namespace Inbursa.Application.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private ILogger<LoanApplicationService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanService _loanService;
        private readonly IProposalRepository _proposalRepository;
        private readonly IPaymentFlowSummaryRepository _summaryRepository;
        private readonly IPropostaValidator _validator;

        public LoanApplicationService(ILogger<LoanApplicationService> logger, IUnitOfWork unitOfWork, ILoanService loanService, IProposalRepository proposalRepository, 
            IPaymentFlowSummaryRepository summaryRepository, IPropostaValidator validator)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _loanService = loanService;
            _proposalRepository = proposalRepository;
            _summaryRepository = summaryRepository;
            _validator = validator;
        }

        public async Task<(bool IsValid, List<string> Errors, PaymentFlowSummaryResponseDto Result)> SimulateLoanAsync(ProposalRequestDto proposalRequestDto)
        {
            try
            {
                _logger.LogInformation($"{nameof(LoanApplicationService)} - Starting Loan Simulation");
                var proposal = new Proposal(proposalRequestDto.LoanAmount, proposalRequestDto.AnnualInterestRate, proposalRequestDto.NumberOfMonths);

                var validationErrors = _validator.Validate(proposal);
                if (validationErrors.Any())
                    return (false, validationErrors, null);

                await _unitOfWork.BeginTransactionAsync();
                await _proposalRepository.AddAsync(proposal);
                await _unitOfWork.SaveAsync();
         
                var result = _loanService.SimulateLoan(proposal);
                
                await _summaryRepository.AddAsync(result);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitAsync();

                var responseDto = new PaymentFlowSummaryResponseDto
                {
                    MonthlyPayment = result.MonthlyPayment,
                    TotalInterest = result.TotalInterest,
                    TotalPayment = result.TotalPayment,
                    PaymentSchedule = result.PaymentSchedule.Select(p => new PaymentDetailResponseDto
                    {
                        Month = p.Month,
                        Principal = p.Principal,
                        Interest = p.Interest,
                        Balance = p.Balance
                    }).ToList()
                };

                return (true, new List<string>(), responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Occurred an error to computed a loan simulation");
                await _unitOfWork.CommitAsync();
                throw;
            }            
        }
    }
}
