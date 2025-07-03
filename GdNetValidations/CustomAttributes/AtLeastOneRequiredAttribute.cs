using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GdNetValidations.CustomAttributes
{
    public class AtLeastOneRequiredAttribute : ValidationAttribute
    {
        private readonly string[] _propertyNames;

        public AtLeastOneRequiredAttribute(params string[] propertyNames)
        {
            _propertyNames = propertyNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var type = validationContext.ObjectType;
            var isAnyNotEmpty = _propertyNames.Any(propertyName =>
            {
                var property = type.GetProperty(propertyName);
                var propertyValue = property?.GetValue(validationContext.ObjectInstance) as string;
                return !string.IsNullOrWhiteSpace(propertyValue);
            });

            if (!isAnyNotEmpty)
            {
                return new ValidationResult($"At least one of the following fields must be provided: {string.Join(", ", _propertyNames)}");
            }

            return ValidationResult.Success;
        }
    }
}
