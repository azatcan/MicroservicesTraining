﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.WebApp.Models.Orders
{
    public class OrderCreatedViewModel
    {
        public int OrderId { get; set; }

        public string Error { get; set; }
        public bool IsSuccessful { get; set; }
    }
}