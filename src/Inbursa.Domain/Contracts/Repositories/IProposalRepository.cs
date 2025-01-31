using Inbursa.Domain.Entities;

namespace Inbursa.Domain.Contracts.Repositories
{
    public interface IProposalRepository
    {
        Task AddAsync(Proposal proposal);
    }
}
