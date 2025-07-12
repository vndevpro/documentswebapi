using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Application.Extensions
{
    public static class DocumentMapper
    {
        public static Document ToDocument(this CreateDocumentInputModel inputModel, string creatorId)
        {
            return Document.Create(creatorId, inputModel.Title, inputModel.Description);
        }

        public static Document GetValuesFromInputModel(this Document document, UpdateDocumentInputModel inputModel)
        {
            document.ChangeDetails(inputModel.Title, inputModel.Description);
            return document;
        }
    }
}
