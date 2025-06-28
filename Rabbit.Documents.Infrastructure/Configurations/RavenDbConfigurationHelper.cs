using GdNetDataStoreRavenDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class RavenDbConfigurationHelper
    {
        public static void ConfigRavenDb(this IServiceCollection services, IConfiguration configuration, string configSectionName = "RavenDbSettings")
        {
            var dbSettings = configuration.GetSection<RavenDbSettings>(configSectionName);

            services.ConfigRavenDb(dbSettings);
        }

        public static void ConfigRavenDb(this IServiceCollection services, RavenDbSettings settings)
        {
            var store = DocumentStoreFactory.CreateStore(settings);

            services.AddSingleton(store);

            services.AddScoped(sp => sp.GetRequiredService<IDocumentStore>().OpenAsyncSession());
        }
    }
}
