using MediatR;
using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Application.Extensions;
using Rabbit.Documents.Application.ViewModels;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Application.Handlers.Commands
{
    public class UpdateDocumentCommandHandler(IDocumentRepository documentRepository) : IRequestHandler<UpdateDocumentCommand, DocumentViewModel>
    {
        public async Task<DocumentViewModel> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = documentRepository.GetById(request.DocumentId);

            existingEntity.GetValuesFromInputModel(request.InputModel);
            var document = await documentRepository.CreateOrUpdateAsync(existingEntity);

            return document.MapToViewModel();
        }
    }
}
