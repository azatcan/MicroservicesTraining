using CatalogService.Application.Dtos;
using CategoryService.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Services.Abstract
{
    public interface IGenericService<TDto> where TDto : class,new()
    {
        Task<Response<List<TDto>>> GetAllAsync();
        Task<Response<TDto>> GetByIdAsync(string id);
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<NoContent>> UpdateAsync(string id, TDto entity);
    }
}
