using CategoryService.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Dtos;
using OrderService.Application.Mapping;
using OrderService.Application.Queries;
using OrderService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly DataContext _dataContext;

        public GetOrdersByUserIdQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _dataContext.Orders.Include(x=>x.OrderItems).Where(x=> x.BuyerId==request.UserId).ToListAsync();
            if (orders.Count == 0) 
            {
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), 204);
            }
            var orderDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);
            return Response<List<OrderDto>>.Success(orderDto, 200);
        }
    }
}
