using System.Reflection;
using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//para cambiar el formato de respuesta
builder.Services.AddControllers( options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true; //envia error si no es soportado el formato que se quiere usar

}).AddXmlSerializerFormatters();

builder.Services.ConfigureCors();//configuracion de las cors
builder.Services.AddApplicationServices(); //configuracion de la UnitOfWork(repo-interface) y otras cosas mas
builder.Services.AddJwt(builder.Configuration); //definir los parametros del JWT para añadir 
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly()); //habilitar el AutoMapper
builder.Services.ConfigureRateLimiting();//habilitar la configuracion del numero de peticiones 
builder.Services.ConfigureApiVersioning(); //habilitar las versiones o versionado en el proyecto para las Apis 

//habilitamos la conexion a la base de datos 
builder.Services.AddDbContext<ReporteAppIncidenciasContext>(OptionsBuilder =>
{
    string? ConnectionString = builder.Configuration.GetConnectionString("ConexMysql");
    OptionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//activar migraciones pendientes 
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   var loggerFactory = services.GetRequiredService<ILoggerFactory>();
   try
    {
        var context = services.GetRequiredService<ReporteAppIncidenciasContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrió un error durante la migración");
    }
} 

app.UseIpRateLimiting();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//server = 192.168.128.209; user = apolo; password = Apo1oC@mp3r;
//server = localhost; user = root; password = 123456789;
//dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
//dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.2