using MediatR;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.ViewModels;

namespace Rabbit.Documents.Application.Queries
{
    public sealed class AdvancedSearchDocumentsQuery : IRequest<PaginatedResult<DocumentViewModel>>
    {
        public required AdvancedSearchQueryModel InputModel { get; set; }
    }
}
