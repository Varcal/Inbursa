using Inbursa.Domain.Contracts.Repositories;
using Inbursa.Domain.Entities;
using Inbursa.Infra.Data.Contexts;

namespace Inbursa.Infra.Data.Repositories
{
    public class PaymentFlowSummaryRepository : IPaymentFlowSummaryRepository
    {
        private readonly EfDbContext _context;

        public PaymentFlowSummaryRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PaymentFlowSummary summary)
        {
           await _context.PaymentFlowSummaries.AddAsync(summary);
        }
    }
}
