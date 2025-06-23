using Rabbit.Documents.Application.Commands;
using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Application.Extensions
{
    public static class DocumentInputModelsExtensions
    {
        public static Document ToDocument(this CreateDocumentInputModel inputModel)
        {
            return Document.Create(inputModel.Title, inputModel.Description);
        }

        public static Document GetValuesFromInputModel(this Document document, UpdateDocumentInputModel inputModel)
        {
            document.ChangeDetails(inputModel.Title, inputModel.Description);
            return document;
        }
    }
}
