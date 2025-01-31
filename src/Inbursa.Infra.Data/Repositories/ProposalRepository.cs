using Inbursa.Domain.Contracts.Repositories;
using Inbursa.Domain.Entities;
using Inbursa.Infra.Data.Contexts;


namespace Inbursa.Infra.Data.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly EfDbContext _context;

        public ProposalRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Proposal proposal)
        {
            await _context.Proposals.AddAsync(proposal);
        }
    }
}
