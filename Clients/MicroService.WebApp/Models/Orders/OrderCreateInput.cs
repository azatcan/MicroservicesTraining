using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.WebApp.Models.Orders
{
    public class OrderCreateInput
    {
        public OrderCreateInput()
        {
            Items = new List<OrderItemCreateInput>();
        }

        public string BuyerId { get; set; }

        public List<OrderItemCreateInput> Items { get; set; }

        public AddressCreateInput Address { get; set; }
    }
}