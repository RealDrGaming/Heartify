using Heartify.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Heartify.Core.Attributes
{
    public class IsAdult : ValidationAttribute
    {
        private readonly DateTime minimumAge = DateTime.Today.AddYears(-18);

        private readonly DateTime maximumAge = DateTime.Today.AddYears(99);

        public IsAdult(int minAge, int maxAge)
        {
            minimumAge = DateTime.Today.AddYears(minAge * -1);
            maximumAge = DateTime.Today.AddYears(maxAge);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime birthDate;

            if (DateTime.TryParseExact(
                        value?.ToString(),
                        ValidationConstants.DateFormat,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out birthDate))
            {
                if (value != null &&
                birthDate.Date <= minimumAge.Date &&
                birthDate.Date <= maximumAge.Date)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}