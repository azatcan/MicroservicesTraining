using CatalogService.Application.Options;
using CatalogService.Application.Services.Abstract;
using CatalogService.Application.Services.Concrete;
using CatalogService.Domain.Repositories;
using CatalogService.Infrastructure.Persistence.DataContext;
using CatalogService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure
{
    public static class Registration
    {
        public static void AddRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOption>(configuration.GetSection("DatabaseSettings"));
            services.AddSingleton<IDatabaseOption>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseOption>>().Value;

            });

            services.AddScoped<MongoDbContext>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
