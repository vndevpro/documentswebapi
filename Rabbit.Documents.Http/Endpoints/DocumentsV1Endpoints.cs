using MediatR;
using Rabbit.Documents.Application;
using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.Queries;
using Rabbit.Documents.Application.ViewModels;
using System.Net;

namespace Rabbit.Documents.Http.Endpoints
{
    static class DocumentsV1Endpoints
    {
        public static void MapDocumentsEndpoints(this IEndpointRouteBuilder routeBuilder)
        {
            var builder = routeBuilder.MapGroup("/documents").WithTags(ApiDocumentations.Tags.Documents);

            builder.MapGet("/",
                async (IMediator mediator, [AsParameters] PaginationQueryModel model) =>
                {
                    var documents = await mediator.Send(new GetDocumentsQuery { InputModel = model });
                    return Results.Ok(documents);
                })
                .WithSummary("Get a page of documents")
                .WithDescription("Returns documents paginated by page size and page number")
                .Produces<PaginatedResult<DocumentViewModel>>();

            builder.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                {
                    var document = await mediator.Send(new GetDocumentByIdQuery { Id = id });
                    return document == null ? Results.NotFound(document) : Results.Ok(document);
                })
                .WithSummary("Get a document by its ID")
                .WithDescription("Return detail of a document")
                .Produces<DocumentViewModel>()
                .ProducesProblem((int)HttpStatusCode.NotFound);

            builder.MapPost("/",
                async (IMediator mediator, HttpContext context, CreateDocumentInputModel model) =>
                {
                    var document = await mediator.Send(new CreateDocumentCommand { InputModel = model });
                    var uri = $"{context.Request.PathBase}/api/v1/documents/{document.Id}";
                    return Results.Created(uri, document);
                })
                .WithSummary("Create a document")
                .WithDescription("Creates then returns detail of the new document")
                .Produces<DocumentViewModel>()
                .ProducesProblem((int)HttpStatusCode.BadRequest)
                .RequireAuthorization();

            builder.MapPatch("/{id:guid}",
                async (IMediator mediator, Guid id, UpdateDocumentInputModel model) =>
                {
                    var document = await mediator.Send(new UpdateDocumentCommand(id, model));
                    return Results.Ok(document);
                })
                .WithSummary("Update an existing document")
                .WithDescription("Updates then returns detail of the document")
                .Produces<DocumentViewModel>()
                .ProducesProblem((int)HttpStatusCode.NotFound);

            builder.MapGet("/search",
                async (IMediator mediator, [AsParameters] GenericSearchQueryModel model) =>
                {
                    var documents = await mediator.Send(new GenericSearchDocumentsQuery { InputModel = model });
                    return Results.Ok(documents);
                })
                .WithSummary("Search for documents by all possible fields")
                .WithDescription("Search then returns a page of documents matched with the input")
                .Produces<PaginatedResult<DocumentViewModel>>();

            builder.MapGet("/advancedsearch",
                async (IMediator mediator, [AsParameters] AdvancedSearchQueryModel model) =>
                {
                    var documents = await mediator.Send(new AdvancedSearchDocumentsQuery { InputModel = model });
                    return Results.Ok(documents);
                })
                .WithSummary("Search for documents in advanced mode")
                .WithDescription("Search in exact mode then returns a page of matched documents")
                .Produces<PaginatedResult<DocumentViewModel>>();
        }
    }
}
