using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Taboo.Exceptions;
using Taboo.Service.Abstracts;
using Taboo.Service.Implements;

namespace Taboo
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILAnguageService, LanguageService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IBannedWordService, BannedWordService>();
            services.AddScoped<IGameService, GameService>();

            return services;
        }
        public static IApplicationBuilder UseTaboExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                options =>
                {
                    options.Run(async context =>
                    {
                        var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                        var exception = feature.Error;
                        if (exception is IBaseException bEx)
                        {
                            context.Response.StatusCode = bEx.StatusCode;
                            await context.Response.WriteAsJsonAsync(new { message = bEx.ErrorMessage });

                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new { message = "Bir xeta bas verdi" });
                        }


                    });
                });
            return app;
        }
    }
}
