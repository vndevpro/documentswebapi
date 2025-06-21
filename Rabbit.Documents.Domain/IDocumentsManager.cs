namespace Rabbit.Documents.Domain
{
    public interface IDocumentsManager
    {
        Document Add(Document document);
        void Delete(Guid id);
        Document? Get(Guid id);
        IEnumerable<Document> GetAll();
    }
}
