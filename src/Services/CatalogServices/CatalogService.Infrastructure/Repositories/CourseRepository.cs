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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public CourseRepository(MongoDbContext mongoDbContext, IOptions<DatabaseOption> databaseOptions) : base(mongoDbContext, databaseOptions.Value.CourseCollectionName)
        {
            _courseCollection = mongoDbContext.GetCollection<Course>(databaseOptions.Value.CourseCollectionName);
            _categoryCollection = mongoDbContext.GetCollection<Category>(databaseOptions.Value.CategoryCollectionName);
        }

        public async Task<List<Course>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find<Course>(x=> x.UserId == userId).ToListAsync();
            if (courses.Any()) 
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x=>x.Id == course.Id).FirstOrDefaultAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }
            return courses;
        }
    }
}
