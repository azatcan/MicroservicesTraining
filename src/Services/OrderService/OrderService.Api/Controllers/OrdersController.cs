﻿using CategoryService.Shared.ControllerBases;
using CategoryService.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Commands;
using OrderService.Application.Queries;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrdersByUserIdQuery{ UserId = _sharedIdentityService.GetUserId});

            return CreateActionResultInstance(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return CreateActionResultInstance(response);
        }
    }
}
