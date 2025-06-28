using GdNetDDD.Common;
using GdNetValidations;
using MediatR;
using Rabbit.Documents.Application.ViewModels;

namespace Rabbit.Documents.Application.Queries
{
    public class GetDocumentsQuery : IRequest<PaginatedResult<DocumentViewModel>>
    {
        public required PaginationInputModel InputModel { get; set; }
    }
}
