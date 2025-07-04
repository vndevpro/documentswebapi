using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Rabbit.Documents.Infrastructure.Configurations
{
    public static class OpenApiConfigurationHelper
    {
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        public static void ConfigOpenApi(this IServiceCollection services)
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, token) =>
                {
                    document.Info.Title = "Rabbit Documents APIs";
                    document.Info.Description = "Opensource Documents Management APIs written in C#, WebAPI and NoSQL database.";
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "Github Repository",
                        Url = new Uri("https://github.com/vndevpro/documentswebapi")
                    };

                    return Task.CompletedTask;
                });
            });
        }

        public static void UseOpenApiUI(this WebApplication app)
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }
    }
}
