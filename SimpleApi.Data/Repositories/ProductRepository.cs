using Microsoft.EntityFrameworkCore;
using SimpleApi.Data.Context;
using SimpleApi.Domain.Entities;
using SimpleApi.Domain.Interfaces;

namespace SimpleApi.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .Include(x => x.Category)
                .ToListAsync();
        }

        public override async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
