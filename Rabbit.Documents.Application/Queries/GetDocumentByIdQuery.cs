using MediatR;
using Rabbit.Documents.Application.ViewModels;

namespace Rabbit.Documents.Application.Queries
{
    public class GetDocumentByIdQuery : IRequest<DocumentViewModel>
    {
        public Guid Id { get; set; }
    }
}
