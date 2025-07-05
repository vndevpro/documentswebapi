namespace Rabbit.Documents.Http.Endpoints
{
    public static class EndpointsHelper
    {
        public static void MapApiEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapDocumentsV1Endpoints();
        }
    }
}
