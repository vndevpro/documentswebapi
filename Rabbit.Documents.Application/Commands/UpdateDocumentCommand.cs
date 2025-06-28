using MediatR;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.ViewModels;

namespace Rabbit.Documents.Application.Commands
{
    public class UpdateDocumentCommand : IRequest<DocumentViewModel>
    {
        public string DocumentId { get; init; }

        public UpdateDocumentInputModel InputModel { get; init; }

        public UpdateDocumentCommand(Guid documentId, UpdateDocumentInputModel inputModel)
        {
            DocumentId = documentId.ToString();
            InputModel = inputModel;
        }
    }
}
