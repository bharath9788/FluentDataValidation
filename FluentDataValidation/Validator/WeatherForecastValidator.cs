using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentDataValidation.Validator
{
    public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastValidator()
        {
            RuleFor(p => p.Summary).NotEmpty().WithMessage("{PropertyName} Cannot be Empty. Enter valid summary")
                .Length(2, 50).WithMessage("{Length {TotalLength} for {PropertyName}  is invalid}")
                .Must(hasValidCharacters).WithMessage("{PropertyName} has invalid characters");
        }

        private bool hasValidCharacters(string summary)
        {
            return summary.All(Char.IsLetter);
        }
    }
}
