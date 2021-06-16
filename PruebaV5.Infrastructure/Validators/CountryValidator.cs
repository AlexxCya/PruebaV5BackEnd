using FluentValidation;
using PruebaV5.Core.DTOs;
using System;

namespace PruebaV5.Infrastructure.Validators
{
    public class CountryValidator : AbstractValidator<CountryDto>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull();

            RuleFor(c => c.Alpha2Code)
                .NotNull()
                .Length(1, 2);

            RuleFor(c => c.Alpha3Code)
                .NotNull()
                .Length(1, 3);
        }
    }
}
