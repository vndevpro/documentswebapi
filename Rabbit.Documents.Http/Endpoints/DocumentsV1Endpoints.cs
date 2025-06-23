using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.Extensions;
using Rabbit.Documents.Http.Mocks;

namespace Rabbit.Documents.Http.Endpoints
{
    static class DocumentsV1Endpoints
    {
        public static void MapDocumentsEndpoints(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapGet("/documents", () =>
            {
                return Results.Ok(MockedDocumentRepository.Instance.GetAll(null, null));
            });

            routeBuilder.MapGet("/documents/{id:guid}", (Guid id) =>
            {
                var entity = MockedDocumentRepository.Instance.GetById(id);
                return entity == null ? Results.NotFound(entity) : Results.Ok(entity);
            });

            routeBuilder.MapPost("/documents", (CreateDocumentInputModel documentInputModel) =>
            {
                var createdEntity = MockedDocumentRepository.Instance.Create(documentInputModel.ToDocument());
                return Results.Created($"/documents/{createdEntity.Id}", createdEntity);
            });

            routeBuilder.MapPatch("/documents/{id:guid}", (Guid id, UpdateDocumentInputModel documentInputModel) =>
            {
                var existingEntity = MockedDocumentRepository.Instance.GetById(id);
                if (existingEntity == null)
                {
                    return Results.NotFound($"Document with ID {id} not found.");
                }

                existingEntity.GetValuesFromInputModel(documentInputModel);
                var updatedEntity = MockedDocumentRepository.Instance.Update(existingEntity);

                return Results.Ok(updatedEntity);
            });
        }
    }
}
