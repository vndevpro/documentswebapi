using Raven.Client.Documents;
using System.Security.Cryptography.X509Certificates;

namespace Rabbit.Documents.Http.Configurations
{
    public static class DocumentStoreFactory
    {
        /// <summary>
        /// Creates and initializes a new instance of IDocumentStore.
        /// </summary>
        /// <returns>An initialized IDocumentStore instance.</returns>
        public static IDocumentStore CreateStore(RavenDbSettings dbSettings)
        {
            var certificate = new X509Certificate2(dbSettings.CertificatePath);

            IDocumentStore store = new DocumentStore()
            {
                // Define the cluster node URLs (required)
                Urls = dbSettings.Urls,

                // Set conventions as necessary (optional)
                Conventions =
                {
                    MaxNumberOfRequestsPerSession = 10,
                    UseOptimisticConcurrency = true,
                    DisposeCertificate = false,
                },

                // Define a default database (optional)
                Database = dbSettings.Database,

                // Define a client certificate (optional)
                Certificate = certificate,

                // Initialize the Document Store
            }.Initialize();

            return store;
        }
    }
}
