using SimpleApi.Data.Context;
using SimpleApi.Domain.Entities;
using SimpleApi.Domain.Interfaces;

namespace SimpleApi.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
