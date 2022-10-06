using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cu => cu.UserId).Empty();
            RuleFor(cu => cu.CompanyName).Empty();
            RuleFor(cu => cu.CompanyName).MinimumLength(2);
        }
    }
}
