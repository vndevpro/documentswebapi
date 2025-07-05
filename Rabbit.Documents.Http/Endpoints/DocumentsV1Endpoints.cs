using MediatR;
using Rabbit.Documents.Application;
using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.Queries;
using Rabbit.Documents.Application.ViewModels;
using Rabbit.Documents.Infrastructure.Validations;
using System.Net;

namespace Rabbit.Documents.Http.Endpoints
{
    static class DocumentsV1Endpoints
    {
        public static void MapDocumentsV1Endpoints(this IEndpointRouteBuilder app)
        {
            var v1Endpoints = app.MapGroup("/api/v1")
                .WithTags(ApiDocumentations.Tags.Documents)
                .AddEndpointFilter<DataAnnotationsValidationFilter>();

            v1Endpoints.MapGet("/documents",
                async (IMediator mediator, [AsParameters] PaginationQueryModel model) =>
                {
                    var documents = await mediator.Send(new GetDocumentsQuery { InputModel = model });
                    return Results.Ok(documents);
                })
                .WithSummary("Get a page of documents")
                .WithDescription("Returns documents paginated by page size and page number")
                .Produces<PaginatedResult<DocumentViewModel>>();

            v1Endpoints.MapGet("/documents/{id:guid}",
                async (IMediator mediator, Guid id) =>
                {
                    var document = await mediator.Send(new GetDocumentByIdQuery { Id = id });
                    return document == null ? Results.NotFound(document) : Results.Ok(document);
                })
                .WithSummary("Get a document by its ID")
                .WithDescription("Return detail of a document")
                .Produces<DocumentViewModel>()
                .ProducesProblem((int)HttpStatusCode.NotFound);

            v1Endpoints.MapPost("/documents",
                async (IMediator mediator, HttpContext context, CreateDocumentInputModel model) =>
                {
                    var document = await mediator.Send(new CreateDocumentCommand { InputModel = model });
                    var uri = $"{context.Request.PathBase}/api/v1/documents/{document.Id}";
                    return Results.Created(uri, document);
                })
                .WithSummary("Create a document")
                .WithDescription("Creates then returns detail of the new document")
                .Produces<DocumentViewModel>()
                .ProducesProblem((int)HttpStatusCode.BadRequest);

            v1Endpoints.MapPatch("/documents/{id:guid}",
                async (IMediator mediator, Guid id, UpdateDocumentInputModel model) =>
                {
                    var document = await mediator.Send(new UpdateDocumentCommand(id, model));
                    return Results.Ok(document);
                })
                .WithSummary("Update an existing document")
                .WithDescription("Updates then returns detail of the document")
                .Produces<DocumentViewModel>()
                .ProducesProblem((int)HttpStatusCode.NotFound);

            v1Endpoints.MapGet("/documents/search",
                async (IMediator mediator, [AsParameters] GenericSearchQueryModel model) =>
                {
                    var documents = await mediator.Send(new GenericSearchDocumentsQuery { InputModel = model });
                    return Results.Ok(documents);
                })
                .WithSummary("Search for documents by all possible fields")
                .WithDescription("Search then returns a page of documents matched with the input")
                .Produces<PaginatedResult<DocumentViewModel>>();

            v1Endpoints.MapGet("/documents/advancedsearch",
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
