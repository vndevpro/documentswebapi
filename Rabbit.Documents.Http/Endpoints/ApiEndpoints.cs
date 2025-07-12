using Rabbit.Documents.Http.Validations;
using Rabbit.Documents.Security;

namespace Rabbit.Documents.Http.Endpoints
{
    public static class ApiEndpoints
    {
        public static void MapApiV1Endpoints(this IEndpointRouteBuilder app)
        {
            var apiV1 = app.MapGroup("/api/v1").AddEndpointFilter<DataAnnotationsValidationFilter>();

            apiV1.MapDocumentsEndpoints();
        }

        public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var usersGroup = app.MapGroup("/api/v1/users");
            usersGroup.MapIdentityApi<AppUser>();
        }
    }
}
