using MediatR;
using Rabbit.Documents.Application.Queries;
using Rabbit.Documents.Application.ViewModels;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Application.Handlers.Queries
{
    public class GetDocumentByIdQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<GetDocumentByIdQuery, DocumentViewModel>
    {
        public async Task<DocumentViewModel> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var document = await documentRepository.GetByIdAsync(request.Id.ToString());

            return document.MapToViewModel();
        }
    }
}
