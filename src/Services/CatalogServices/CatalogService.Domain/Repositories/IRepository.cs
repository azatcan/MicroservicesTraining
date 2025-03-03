using CatalogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Repositories
{
    public interface IRepository<T> where T : class,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddAsync(T entity);
        Task<bool> DeleteAsync(string id);
        Task<bool> UpdateAsync(string id, T entity);
    }
}
