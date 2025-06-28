using MediatR;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.ViewModels;

namespace Rabbit.Documents.Application.Commands
{
    public class CreateDocumentCommand : IRequest<DocumentViewModel>
    {
        public required CreateDocumentInputModel InputModel { get; set; }
    }
}
