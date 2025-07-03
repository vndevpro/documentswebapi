using MediatR;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.ViewModels;

namespace Rabbit.Documents.Application.Queries
{
    public class GenericSearchDocumentsQuery : IRequest<PaginatedResult<DocumentViewModel>>
    {
        public required GenericSearchQueryModel InputModel { get; set; }
    }
}
