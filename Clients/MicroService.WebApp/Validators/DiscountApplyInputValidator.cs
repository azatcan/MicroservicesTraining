using FluentValidation;
using MicroService.WebApp.Models.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.WebApp.Validators
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        //public DiscountApplyInputValidator()
        //{
        //    RuleFor(x => x.Code).NotEmpty().WithMessage("indirim kupon alanı boş olamaz");
        //}
    }
}