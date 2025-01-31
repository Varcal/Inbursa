namespace Inbursa.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task<int> SaveAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
