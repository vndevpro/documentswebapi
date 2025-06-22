using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.Extensions;
using Rabbit.Documents.Domain;

namespace Rabbit.Documents.Http.Endpoints
{
    public static class DocumentsEndpoints
    {
        public static void MapDocumentsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/documents", () =>
            {
                return Results.Ok(DocumentsManager.Instance.GetAll());
            });

            app.MapGet("/documents/{id:guid}", (Guid id) =>
            {
                var entity = DocumentsManager.Instance.Get(id);
                return entity == null ? Results.NotFound(entity) : Results.Ok(entity);
            });

            app.MapPost("/documents", (CreateDocumentInputModel documentInputModel) =>
            {
                var createdEntity = DocumentsManager.Instance.Add(documentInputModel.ToDocument());
                return Results.Created($"/documents/{createdEntity.Id}", createdEntity);
            });
        }
    }
}
