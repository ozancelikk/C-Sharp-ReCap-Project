using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).Empty();
            RuleFor(r => r.ReturnDate).Equal(DateTime.Now);
            RuleFor(r => r.CarId).Empty();
            RuleFor(r => r.CarId).GreaterThanOrEqualTo(0);
            RuleFor(r => r.CustomerId).Empty();
            RuleFor(r => r.CustomerId).GreaterThanOrEqualTo(0);
        }
    }
}
