
namespace TestConcepts.CustomMiddleware
{
    public class TestMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from TestMiddleware 1");
            await next(context);
            await context.Response.WriteAsync("Hello from TestMiddleware 1");
        }
    }
}
