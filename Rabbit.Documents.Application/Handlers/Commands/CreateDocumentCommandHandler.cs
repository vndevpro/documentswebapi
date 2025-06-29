using MediatR;
using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.Extensions;
using Rabbit.Documents.Application.ViewModels;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Application.Handlers.Commands
{
    public class CreateDocumentCommandHandler(IDocumentRepository documentRepository) : IRequestHandler<CreateDocumentCommand, DocumentViewModel>
    {
        public async Task<DocumentViewModel> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await documentRepository.CreateOrUpdateAsync(request.InputModel.ToDocument());
            return document.MapToViewModel();
        }
    }
}
