using GdNetValidations;
using MediatR;
using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.Queries;

namespace Rabbit.Documents.Http.Endpoints
{
    static class DocumentsV1Endpoints
    {
        public static void MapDocumentsEndpoints(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapGet("/documents", async (IMediator mediator, [AsParameters] PaginationInputModel model) =>
            {
                var documents = await mediator.Send(new GetDocumentsQuery { InputModel = model });
                return Results.Ok(documents);
            });

            routeBuilder.MapGet("/documents/{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var document = await mediator.Send(new GetDocumentByIdQuery { Id = id });
                return document == null ? Results.NotFound(document) : Results.Ok(document);
            });

            routeBuilder.MapPost("/documents", async (IMediator mediator, CreateDocumentInputModel model) =>
            {
                var document = await mediator.Send(new CreateDocumentCommand { InputModel = model });
                return Results.Created($"/documents/{document.Id}", document);
            });

            routeBuilder.MapPatch("/documents/{id:guid}", async (IMediator mediator, Guid id, UpdateDocumentInputModel model) =>
            {
                var document = await mediator.Send(new UpdateDocumentCommand(id, model));
                return Results.Ok(document);
            });
        }
    }
}
