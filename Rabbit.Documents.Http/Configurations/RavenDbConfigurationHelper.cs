using Raven.Client.Documents;

namespace Rabbit.Documents.Http.Configurations
{
    public static class RavenDbConfigurationHelper
    {
        public static void ConfigRavenDb(this IHostApplicationBuilder builder, string configSectionName = "RavenDbSettings")
        {
            var dbSettings = builder.Configuration.GetSection<RavenDbSettings>(configSectionName);

            builder.ConfigRavenDb(dbSettings);
        }

        public static void ConfigRavenDb(this IHostApplicationBuilder builder, RavenDbSettings settings)
        {
            var store = DocumentStoreFactory.CreateStore(settings);

            builder.Services.AddSingleton(store);

            builder.Services.AddScoped(sp => sp.GetRequiredService<IDocumentStore>().OpenAsyncSession());
        }
    }
}
