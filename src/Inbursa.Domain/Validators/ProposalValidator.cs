using Inbursa.Domain.Entities;


namespace Inbursa.Domain.Validators
{
    public class PropostaValidator : IPropostaValidator
    {
        public List<string> Validate(Proposal proposal)
        {
            var errors = new List<string>();

            if (proposal.LoanAmount <= 0)
                errors.Add("Loan amount must be greater than zero.");

            if (proposal.AnnualInterestRate <= 0 || proposal.AnnualInterestRate > 1)
                errors.Add("Annual interest rate must be between 0 and 1 (exclusive).");

            if (proposal.NumberOfMonths <= 0)
                errors.Add("Number of months must be greater than zero.");

            return errors;
        }

       
    }
}
