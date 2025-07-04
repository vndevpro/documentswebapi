using Microsoft.Extensions.DependencyInjection;
using Rabbit.Documents.DataRavenDb.Repositories;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class ApplicationServicesConfigurationHelper
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
