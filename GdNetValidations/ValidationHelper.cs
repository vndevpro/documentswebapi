using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GdNetValidations
{
    public static class ValidationHelper
    {
        public static bool Validate<T>(this T inputModel, out List<ValidationResult> errors) where T : IValidationRequired
        {
            errors = new List<ValidationResult>();

            if (inputModel == null)
            {
                return false;
            }

            var validationContext = new ValidationContext(inputModel);
            return Validator.TryValidateObject(inputModel, validationContext, errors, true);
        }
    }
}
