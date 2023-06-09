﻿using SimpleApi.Data.Context;
using SimpleApi.Domain.Entities;
using SimpleApi.Domain.Interfaces;

namespace SimpleApi.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
