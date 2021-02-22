using Microsoft.AspNetCore.Builder;
using PersonRegister.Presentation.WebApi.Middlewares;

namespace PersonRegister.Presentation.WebApi.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UsePersonRegisterExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }
    }
}
