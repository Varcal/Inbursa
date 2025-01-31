namespace Inbursa.Domain.Entities
{
    public class Proposal
    {
        public int Id { get; private set; }
        public decimal LoanAmount { get; private set; }
        public decimal AnnualInterestRate { get; private set; }
        public int NumberOfMonths { get; private set; }


        private Proposal() { } 

        public Proposal(decimal loanAmount, decimal annualInterestRate, int numberOfMonths)
        {
            LoanAmount = loanAmount;
            AnnualInterestRate = annualInterestRate;
            NumberOfMonths = numberOfMonths;
        }
    }
}
