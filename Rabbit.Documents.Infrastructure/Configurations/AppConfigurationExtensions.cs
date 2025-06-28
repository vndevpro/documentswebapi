using Microsoft.Extensions.DependencyInjection;
using Rabbit.Documents.Domain.Repositories;
using Rabbit.Documents.RavenDbData;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class AppConfigurationExtensions
    {
        public static void ConfigApplicationServices(this IServiceCollection services)
        {
            services.ConfigMediatR();
            services.ConfigRepositories();
        }

        private static void ConfigRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
        }
    }
}
