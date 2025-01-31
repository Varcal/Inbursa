using Inbursa.Domain.Contracts.Services;
using Inbursa.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Inbursa.Domain.Services
{
    public class LoanService : ILoanService
    {
        private ILogger<LoanService> _logger;

        public LoanService(ILogger<LoanService> logger)
        {
            _logger = logger;
        }


        public PaymentFlowSummary SimulateLoan(Proposal proposal)
        {
            _logger.LogInformation($"{nameof(LoanService)} - Computing loan simulation");

            decimal monthlyRate = proposal.AnnualInterestRate / 12;
            int totalMonths = proposal.NumberOfMonths;
            decimal loanAmount = proposal.LoanAmount;

            decimal monthlyPayment = Math.Round(
                loanAmount * (monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), totalMonths)) /
                ((decimal)Math.Pow((double)(1 + monthlyRate), totalMonths) - 1), 2);

            decimal remainingBalance = loanAmount;
            decimal totalInterest = 0;
            var schedule = new List<PaymentDetail>();

            for (int month = 1; month <= totalMonths; month++)
            {
                decimal interest = Math.Round(remainingBalance * monthlyRate, 2);
                decimal principal = Math.Round(monthlyPayment - interest, 2);

                if (month == totalMonths)
                {
                    principal = remainingBalance;  
                    remainingBalance = 0.00m;
                }
                else
                {
                    remainingBalance = Math.Round(remainingBalance - principal, 2);
                }

                totalInterest = Math.Round(totalInterest + interest, 2);

                schedule.Add(new PaymentDetail(month, principal, interest, remainingBalance));
            }

            _logger.LogInformation($"{nameof(LoanService)} - Computed loan simulation");

            return new PaymentFlowSummary(monthlyPayment, Math.Round(totalInterest, 2), Math.Round(monthlyPayment * totalMonths, 2), schedule);
        }
    }
}
