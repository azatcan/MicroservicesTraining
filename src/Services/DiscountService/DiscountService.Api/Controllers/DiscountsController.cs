using CategoryService.Shared.ControllerBases;
using CategoryService.Shared.Services;
using DiscountService.Api.Models;
using DiscountService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly ISharedIdentityService _identityService;
        private readonly IDiscountService _discountService;

        public DiscountsController(ISharedIdentityService identityService, IDiscountService discountService)
        {
            _identityService = identityService;
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var getAll = await _discountService.GetAll();
            return CreateActionResultInstance(getAll);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetById(id);
            return CreateActionResultInstance(discount);
        }

        [HttpGet]
        [Route("/api/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _identityService.GetUserId;
            var discount = await _discountService.GetByCodeAndUserId(code, userId);
            return CreateActionResultInstance(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            var save = await _discountService.Save(discount);
            return CreateActionResultInstance(save);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            var update = await _discountService.Update(discount);
            return CreateActionResultInstance(update);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _discountService.Delete(id);
            return CreateActionResultInstance(delete);
        }
    }
}
