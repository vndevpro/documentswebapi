using Microsoft.Extensions.DependencyInjection;
using Rabbit.Documents.Application;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class MediatorExtensions
    {
        public static void ConfigMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<ApplicationLayer>();
            });
        }
    }
}
