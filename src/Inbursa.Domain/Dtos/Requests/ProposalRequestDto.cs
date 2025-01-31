namespace Inbursa.Domain.Dtos.Requests
{
    public class ProposalRequestDto
    {
        public decimal LoanAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public int NumberOfMonths { get; set; }
    }
}
