using AutoMapper;
using CatalogService.Application.Dtos;
using CatalogService.Application.Services.Abstract;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using CategoryService.Shared.Dtos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CategoryManager(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<CategoryDto>> AddAsync(CategoryDto entity)
        {
            var category = _mapper.Map<Category>(entity);
            await _repository.AddAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _repository.DeleteAsync(id);
            if (result == null)
            {
                return Response<NoContent>.Fail("Delete Not succes", 404);
            }
            else
            {
                return Response<NoContent>.Success(204);           
            }
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories),200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _repository.GetByIdAsync(id);
            if(category == null)
            {
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);
            
        }

        public Task<Response<NoContent>> UpdateAsync(string id, CategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
