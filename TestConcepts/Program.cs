
using TestConcepts.CustomMiddleware;

namespace TestConcepts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<TestMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Configure the HTTP request pipeline.
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from middleware 1");
                await next();
                await context.Response.WriteAsync("Hello from middleware 1");
            });

            app.UseMiddleware<TestMiddleware>();

            app.Run();
        }
    }
}
