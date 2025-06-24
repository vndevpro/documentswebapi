using Rabbit.Documents.Http.Configurations;
using Rabbit.Documents.Http.Endpoints;

namespace Rabbit.Documents.Http
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Create and configure the document store
            builder.ConfigRavenDb();

            // Configure application services
            builder.ConfigApplicationServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapApiV1Endpoints();

            app.Run();
        }
    }
}
