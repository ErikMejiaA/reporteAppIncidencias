using Aplicacion.UnitOfWork;
using AspNetCoreRateLimit;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace API.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin() //WithOrigins("https://domini.com")
                    .AllowAnyMethod()       //WithMethods(*GET ", "POST")
                    .AllowAnyHeader()      //WithHeaders(*accept*, "content-type")
                );

        }
    );

    //se define la Unidad de trabajo (interfaz y repository)
    public static void AddApplicationServices( this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkInterface, UnitOfWork>();
    }

    public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(options => 
        {
            options.StackBlockedRequests = false;
            options.HttpStatusCode = 429;
            options.RealIpHeader = "X-Real-IP";
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2
                }
            };

        });
        
    }

    //Control de versiones de Appis (ver versiones de las apis creadas o Enpoint)
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options => {

            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            //options.ApiVersionReader = new QueryStringApiVersionReader("v");
            //options.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("v"),
                new HeaderApiVersionReader("X-Version")
            );
            options.ReportApiVersions = true;

        });
    }
}
