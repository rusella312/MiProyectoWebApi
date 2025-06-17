using Microsoft.EntityFrameworkCore;
using MiProyectoWebApi.Infrastructure.Data;
using MiProyectoWebApi.Services.Features.Mangas;
using MiProyectoWebApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ✅ Cargar configuración (esto ya viene por defecto, solo asegúrate de tener el appsettings.json con la conexión)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Agregar DbContext con MySQL
builder.Services.AddDbContext<MangaDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// ✅ Inyección de dependencias
builder.Services.AddScoped<MangaService>();
builder.Services.AddScoped<MangaRepository>();

// ✅ Controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "MangaBot API",
        Description = "Una API para gestionar una increíble colección de mangas",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Tu Nombre/Equipo",
            Url = new Uri("https://tuwebsite.com")
        }
    });
});

var app = builder.Build();

// ✅ Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MangaBot API V1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
