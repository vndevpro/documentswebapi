using Rabbit.Documents.Http.Validations;

namespace Rabbit.Documents.Http.Endpoints
{
    public static class ApiV1Endpoints
    {
        public static void MapApiV1Endpoints(this IEndpointRouteBuilder app)
        {
            var apiV1 = app.MapGroup("/api/v1").AddEndpointFilter<DataAnnotationsValidationFilter>();

            apiV1.MapDocumentsEndpoints();
        }
    }
}
