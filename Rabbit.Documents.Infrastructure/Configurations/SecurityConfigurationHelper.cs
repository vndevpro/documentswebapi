using Microsoft.Extensions.DependencyInjection;
using Rabbit.Documents.Security;
using Raven.Identity;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class SecurityConfigurationHelper
    {
        public static void ConfigureRavenDbIdentity(this IServiceCollection services)
        {
            services.AddIdentityApiEndpoints<AppUser>()
               .AddRavenDbIdentityStores<AppUser>();
        }
    }
}
