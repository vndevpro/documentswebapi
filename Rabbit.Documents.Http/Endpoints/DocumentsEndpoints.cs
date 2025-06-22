using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.Extensions;
using Rabbit.Documents.Domain;

namespace Rabbit.Documents.Http.Endpoints
{
    public static class DocumentsEndpoints
    {
        public static void MapDocumentsEndpoints(this IEndpointRouteBuilder app)
        {
            var apiV1 = app.MapGroup("/api/v1").AddEndpointFilter<DataAnnotationsValidationFilter>();

            apiV1.MapGet("/documents", () =>
            {
                return Results.Ok(DocumentsManager.Instance.GetAll());
            });

            apiV1.MapGet("/documents/{id:guid}", (Guid id) =>
            {
                var entity = DocumentsManager.Instance.Get(id);
                return entity == null ? Results.NotFound(entity) : Results.Ok(entity);
            });

            apiV1.MapPost("/documents", (CreateDocumentInputModel documentInputModel) =>
            {
                var createdEntity = DocumentsManager.Instance.Add(documentInputModel.ToDocument());
                return Results.Created($"/documents/{createdEntity.Id}", createdEntity);
            });

            apiV1.MapPatch("/documents/{id:guid}", (Guid id, UpdateDocumentInputModel documentInputModel) =>
            {
                var existingEntity = DocumentsManager.Instance.Get(id);
                if (existingEntity == null)
                {
                    return Results.NotFound($"Document with ID {id} not found.");
                }

                existingEntity.GetValuesFromInputModel(documentInputModel);
                var updatedEntity = DocumentsManager.Instance.Update(id, existingEntity);

                return Results.Ok(updatedEntity);
            });
        }
    }
}
