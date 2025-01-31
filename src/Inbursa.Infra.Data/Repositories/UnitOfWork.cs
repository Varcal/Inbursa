using Inbursa.Domain.Contracts.Repositories;
using Inbursa.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inbursa.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfDbContext _efContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EfDbContext efContext)
        {
            _efContext = efContext;
        }
  

        public async Task BeginTransactionAsync()
        {
            _transaction = await _efContext?.Database?.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction?.CommitAsync();
        }    

        public async Task RollbackAsync()
        {
            await _transaction?.RollbackAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _efContext.SaveChangesAsync();
        }
    }
}
