using Microsoft.Extensions.DependencyInjection;
using Rabbit.Documents.DataRavenDb.Indexes;
using Raven.Client.Documents.Indexes;
using Raven.DependencyInjection;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class RavenDbConfigurationHelper
    {
        public static void ConfigRavenDb(this IServiceCollection services)
        {
            services.AddRavenDbDocStore(option =>
                {
                    option.AfterInitializeDocStore = store =>
                    {
                        IndexCreation.CreateIndexes(typeof(SearchableDocumentsIndex).Assembly, store);
                    };
                })
                .AddRavenDbAsyncSession();
        }
    }
}
