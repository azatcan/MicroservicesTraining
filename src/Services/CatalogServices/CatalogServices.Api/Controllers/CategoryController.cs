using CatalogService.Application.Dtos;
using CatalogService.Application.Services.Abstract;
using CategoryService.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get() 
        {
            var response = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            var response = await _categoryService.AddAsync(dto);
            return CreateActionResultInstance(response);
        }
    }
}
