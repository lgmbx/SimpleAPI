using SimpleApi.Data.Context;
using SimpleApi.Domain.Interfaces;

namespace SimpleApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Commit()
        {
            return  _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
