using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.Extensions;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Http.Endpoints
{
    static class DocumentsV1Endpoints
    {
        public static void MapDocumentsEndpoints(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapGet("/documents", (IDocumentRepository documentRepository) =>
            {
                return Results.Ok(documentRepository.GetAll(null, null));
            });

            routeBuilder.MapGet("/documents/{id:guid}", (IDocumentRepository documentRepository, string id) =>
            {
                var entity = documentRepository.GetById(id);
                return entity == null ? Results.NotFound(entity) : Results.Ok(entity);
            });

            routeBuilder.MapPost("/documents", (IDocumentRepository documentRepository, CreateDocumentInputModel documentInputModel) =>
            {
                var createdEntity = documentRepository.CreateOrUpdate(documentInputModel.ToDocument());
                return Results.Created($"/documents/{createdEntity.Id}", createdEntity);
            });

            routeBuilder.MapPatch("/documents/{id:guid}", (IDocumentRepository documentRepository, string id, UpdateDocumentInputModel documentInputModel) =>
            {
                var existingEntity = documentRepository.GetById(id);
                if (existingEntity == null)
                {
                    return Results.NotFound($"Document with ID {id} not found.");
                }

                existingEntity.GetValuesFromInputModel(documentInputModel);
                var updatedEntity = documentRepository.CreateOrUpdate(existingEntity);

                return Results.Ok(updatedEntity);
            });
        }
    }
}
