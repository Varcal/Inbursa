using Inbursa.Domain.Entities;

namespace Inbursa.Domain.Validators
{
    public interface IPropostaValidator
    {
        List<string> Validate(Proposal proposal);
    }
}
