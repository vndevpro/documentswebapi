using Rabbit.Documents.Application.Validations;

namespace Rabbit.Documents.Http.Endpoints
{
    public class DataAnnotationsValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            foreach (var argument in context.Arguments)
            {
                if (argument is IValidationRequired validationRequired)
                {
                    if (!validationRequired.Validate(out var errors))
                    {
                        var errorsDict = errors.ToDictionary(
                            e => e.MemberNames.FirstOrDefault() ?? "Generic",
                            e => e.ErrorMessage
                        );

                        return Results.BadRequest(new
                        {
                            Errors = errorsDict
                        });
                    }
                }
            }

            return await next(context);
        }
    }
}
