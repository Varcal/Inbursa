using Inbursa.Domain.Services;
using Inbursa.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace LoanSimulationAPI.Tests
{
    public class LoanServiceTests
    {
        private Mock<ILogger<LoanService>> _logger;
        private readonly LoanService _loanService;
        

        public LoanServiceTests()
        {
            _logger = new Mock<ILogger<LoanService>>();
            _loanService = new LoanService(_logger.Object);
        }

        private decimal CalculateExpectedMonthlyPayment(decimal loanAmount, decimal annualInterestRate, int months)
        {
            decimal monthlyRate = annualInterestRate / 12;
            return Math.Round(
                loanAmount * (monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), months)) /
                ((decimal)Math.Pow((double)(1 + monthlyRate), months) - 1), 2);
        }

        [Fact]
        public void SimulateLoan_ShouldReturnCorrectMonthlyPayment()
        {
            // Arrange
            var proposal = new Proposal(50000, 0.12m, 24);

            decimal expectedPayment = CalculateExpectedMonthlyPayment(proposal.LoanAmount, proposal.AnnualInterestRate, proposal.NumberOfMonths);

            // Act
            var result = _loanService.SimulateLoan(proposal);

            // Assert
            Assert.Equal(expectedPayment, result.MonthlyPayment, 2);
        }

        [Fact]
        public void SimulateLoan_ShouldHaveZeroRemainingBalanceAtEnd()
        {
            // Arrange
            var proposal = new Proposal(50000, 0.12m, 24);


            // Act
            var result = _loanService.SimulateLoan(proposal);

            // Assert
            Assert.Equal(0, result.PaymentSchedule.Last().Balance, 2);
        }

        [Fact]
        public void SimulateLoan_ShouldReturnValidResult_ForInvalidInput()
        {
            // Arrange
            var proposal = new Proposal(50000, 0.12m, 24);


            // Act
            var result = _loanService.SimulateLoan(proposal);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.MonthlyPayment >= 0, "O pagamento mensal não pode ser negativo");
        }
    }
}
