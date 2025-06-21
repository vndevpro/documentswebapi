
using Rabbit.Documents.Domain;

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/documents", () =>
            {
                return Results.Ok(new Document[]
                    {
                        new Document { Id = Guid.NewGuid(), Title = "Document 1", Description = "Description 1",
                            CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Document { Id = Guid.NewGuid(), Title = "Document 2", Description = "Description 2",
                            CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    });
            });

            app.Run();
        }
    }
}
