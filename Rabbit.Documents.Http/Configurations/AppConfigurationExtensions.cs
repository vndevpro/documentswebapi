using Rabbit.Documents.Domain.Repositories;
using Rabbit.Documents.RavenDbData;

namespace Rabbit.Documents.Http.Configurations
{
    public static class AppConfigurationExtensions
    {
        public static void ConfigApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.ConfigRepositories();
        }

        private static void ConfigRepositories(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
        }
    }
}
