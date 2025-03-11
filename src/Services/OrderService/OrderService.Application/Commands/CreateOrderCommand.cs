using CategoryService.Shared.Dtos;
using MediatR;
using OrderService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Commands
{
    public class CreateOrderCommand:IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> Items { get; set; }

        public AddressDto Address { get; set; }
    }
}
