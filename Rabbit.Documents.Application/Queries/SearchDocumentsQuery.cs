using MediatR;
using Rabbit.Documents.Application.ViewModels;

namespace Rabbit.Documents.Application.Queries
{
    public class SearchDocumentsQuery : IRequest<PaginatedResult<DocumentViewModel>>
    {
        public required SearchQueryModel InputModel { get; set; }
    }
}
