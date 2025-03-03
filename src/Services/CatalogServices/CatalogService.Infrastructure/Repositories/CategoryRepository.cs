using CatalogService.Application.Options;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using CatalogService.Infrastructure.Persistence.DataContext;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        public CategoryRepository(MongoDbContext mongoDbContext, IOptions<DatabaseOption> databaseOptions) : base(mongoDbContext, databaseOptions.Value.CategoryCollectionName)
        {
            _categoryCollection = mongoDbContext.GetCollection<Category>(databaseOptions.Value.CategoryCollectionName);
        }
    }
}
