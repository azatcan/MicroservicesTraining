using CatalogService.Application.Dtos;
using CatalogService.Application.Services.Abstract;
using CategoryService.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("GetAllByUserIdAsync/{userId}")]
        public async Task<IActionResult> GetAllByUserIdAsync(string userId)
        {
            var response = await _courseService.GetAllByUserIdAsync(userId);
            return CreateActionResultInstance(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CourseCreateDto dto)
        {
            var response = await _courseService.AddAsync(dto);
            return CreateActionResultInstance(response);
        }

        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(CourseUpdateDto dto,string id)
        {
            var response = await _courseService.UpdateAsync(id,dto);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }

    }
}
