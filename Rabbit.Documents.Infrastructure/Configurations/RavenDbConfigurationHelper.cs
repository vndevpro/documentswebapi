using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rabbit.Documents.DataRavenDb.Indexes;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.DependencyInjection;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class RavenDbConfigurationHelper
    {
        public static void ConfigRavenDb(this IServiceCollection services)
        {
            services.AddRavenDbDocStore()
                .AddRavenDbAsyncSession()
                .AddRavenDbSession();
        }

        /// <summary>
        /// Creates the RavenDB indexes at application startup.
        /// Use this on app builder rather than after document store initialized event to ensure that all indexes before the first request.
        /// </summary>
        /// <param name="app"></param>
        public static void CreateRavenDbIndexes(this IApplicationBuilder app)
        {
            var store = app.ApplicationServices.GetRequiredService<IDocumentStore>();
            IndexCreation.CreateIndexes(typeof(SearchableDocumentsIndex).Assembly, store);
        }
    }
}
