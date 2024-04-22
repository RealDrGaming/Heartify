using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static Heartify.Infrastructure.Data.Constants.ValidationConstants;

namespace Heartify.Core.Attributes
{
    public class IsAdult : ValidationAttribute
    {
        private readonly DateTime minimumAge = DateTime.Today.AddYears(-MinAge);

        private readonly DateTime maximumAge = DateTime.Today.AddYears(MaxAge);

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime birthDate;

            if (DateTime.TryParseExact(
                        value?.ToString(),
                        DateFormat,
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