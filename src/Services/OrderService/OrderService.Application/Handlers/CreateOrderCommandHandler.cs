using CategoryService.Shared.Dtos;
using MediatR;
using OrderService.Application.Commands;
using OrderService.Application.Dtos;
using OrderService.Domain.OrderAggregate;
using OrderService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly DataContext _context;

        public CreateOrderCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.Items.ForEach(x =>
            {

                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);

            });

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id},200);
        }
    }
}
