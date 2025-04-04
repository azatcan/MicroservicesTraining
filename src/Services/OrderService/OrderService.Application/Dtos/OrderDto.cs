﻿using OrderService.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get;  set; }
        public AddressDto Address { get;  set; }
        public string BuyerId { get;  set; }
        public List<OrderItemDto> OrderItems { get;  set; }

    }
}
