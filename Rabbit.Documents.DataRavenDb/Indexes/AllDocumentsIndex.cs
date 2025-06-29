using Rabbit.Documents.Domain.Entities;
using Raven.Client.Documents.Indexes;

namespace Rabbit.Documents.DataRavenDb.Indexes
{
    public sealed class AllDocumentsIndex : AbstractIndexCreationTask<Document>
    {
        public AllDocumentsIndex()
        {
            Map = documents => from document in documents
                               select new
                               {
                                   document.Id,
                                   document.Title,
                                   document.Description,
                               };

            Index(x => x.Title, FieldIndexing.Search);
            Index(x => x.Description, FieldIndexing.Search);
        }
    }
}
