using Rabbit.Documents.Application.Validations;
using System.ComponentModel.DataAnnotations;

namespace Rabbit.Documents.Application.Validations
{
    public static class ValidationHelper
    {
        public static bool Validate<T>(this T inputModel, out List<ValidationResult> errors) where T : IValidationRequired
        {
            errors = [];

            if (inputModel == null)
            {
                return false;
            }

            var validationContext = new ValidationContext(inputModel);
            return Validator.TryValidateObject(inputModel, validationContext, errors, true);
        }
    }
}
