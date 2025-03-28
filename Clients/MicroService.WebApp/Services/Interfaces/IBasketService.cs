﻿using MicroService.WebApp.Models.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.WebApp.Services.Interfaces
{
    public interface IBasketService
    {
        Task<bool> SaveOrUpdate(BasketViewModel basketViewModel);

        Task<BasketViewModel> Get();

        Task<bool> Delete();

        Task AddBasketItem(BasketItemViewModel basketItemViewModel);

        Task<bool> RemoveBasketItem(string courseId);

        Task<bool> ApplyDiscount(string discountCode);

        Task<bool> CancelApplyDiscount();
    }
}