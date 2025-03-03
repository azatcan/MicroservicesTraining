using CatalogService.Application.Dtos;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using CategoryService.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Services.Abstract
{
    public interface ICourseService : IGenericService<CourseDto>
    {
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
        Task<Response<NoContent>> UpdateAsync(string id, CourseUpdateDto entity);
        Task<Response<CourseCreateDto>> AddAsync(CourseCreateDto entity);
    }
}
