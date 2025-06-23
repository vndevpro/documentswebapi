using Rabbit.Documents.Domain.Entities;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.RavenDbData
{
    public class DocumentRepository : IDocumentRepository
    {
        public IEnumerable<Document> GetAll(int? page, int? pageSize)
        {
            throw new NotImplementedException();
        }

        public Document? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Document Create(Document aggregate)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public Document Update(Document aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
