using System.Reflection;
using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors();//configuracion de las cors
builder.Services.AddApplicationServices(); //configuracion de la UnitOfWork(repo-interface)
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly()); //habilitar el AutoMapper

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
