using AutoMapper;
using CatalogService.Application.Dtos;
using CatalogService.Application.Services.Abstract;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Repositories;
using CategoryService.Shared.Dtos;
using CategoryService.Shared.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Services.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public CourseManager(ICourseRepository courseRepository, ICategoryRepository categoryRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _courseRepository = courseRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<CategoryService.Shared.Dtos.Response<CourseCreateDto>> AddAsync(CourseCreateDto entity)
        {
            var course = _mapper.Map<Course>(entity);
            course.CreatedDate = DateTime.Now;
            await _courseRepository.AddAsync(course);
            return CategoryService.Shared.Dtos.Response<CourseCreateDto>.Success(_mapper.Map<CourseCreateDto>(course), 200);
        }

        public Task<CategoryService.Shared.Dtos.Response<CourseDto>> AddAsync(CourseDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryService.Shared.Dtos.Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _courseRepository.DeleteAsync(id);
            if (result == null)
            {
                return CategoryService.Shared.Dtos.Response<NoContent>.Fail("Delete Not succes", 404);
            }
            else
            {
                return CategoryService.Shared.Dtos.Response<NoContent>.Success(204);
            }
        }

        public async Task<CategoryService.Shared.Dtos.Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            if (courses.Any()) 
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryRepository.GetByIdAsync(course.CategoryId);
                }
            }
            return CategoryService.Shared.Dtos.Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<CategoryService.Shared.Dtos.Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var course = await _courseRepository.GetAllByUserIdAsync(userId);
            return CategoryService.Shared.Dtos.Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(course), 200);
        }

        public async Task<CategoryService.Shared.Dtos.Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return CategoryService.Shared.Dtos.Response<CourseDto>.Fail("Course Not Found", 404);
            }
            course.Category = await _categoryRepository.GetByIdAsync(course.CategoryId);
            return CategoryService.Shared.Dtos.Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<CategoryService.Shared.Dtos.Response<NoContent>> UpdateAsync(string id, CourseUpdateDto entity)
        {
            var course = _mapper.Map<Course>(entity);
            var result = await _courseRepository.UpdateAsync(id, course);
            if(result == null)
            {
                return CategoryService.Shared.Dtos.Response<NoContent>.Fail("Course Not Found", 404);
            }

            await _publishEndpoint.Publish<CourseNameChangedEvent>(new CourseNameChangedEvent
            {
                CourseId = entity.Id,
                UpdatedName = entity.Name,
            });

            return CategoryService.Shared.Dtos.Response<NoContent>.Success(204);
        }

        public Task<CategoryService.Shared.Dtos.Response<NoContent>> UpdateAsync(string id, CourseDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
