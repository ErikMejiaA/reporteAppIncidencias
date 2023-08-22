using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

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
}
