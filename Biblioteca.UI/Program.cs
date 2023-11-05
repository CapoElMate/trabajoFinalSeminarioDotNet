using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Biblioteca.UI.Data;

using Biblioteca.Aplicacion;
using Biblioteca.Repositorios;

var builder = WebApplication.CreateBuilder(args);

//inicio la bdd con algunos datos (metodos de debug):
var iniciarBdd = new IniciarBdd();
iniciarBdd.Ejecutar();

//agregamos estudiantes al contenedor DI
builder.Services.AddTransient<AltaEstudianteUseCase>();
builder.Services.AddTransient<BajaEstudianteUseCase>();
builder.Services.AddTransient<ModificarEstudianteUseCase>();
builder.Services.AddTransient<ListarEstudiantesUseCase>();
builder.Services.AddScoped<IRepositorioEstudiante, RepositorioEstudianteSQLite>();


//agregamos docentes al contenedor DI
builder.Services.AddTransient<AltaDocenteUseCase>();
builder.Services.AddTransient<BajaDocenteUseCase>();
builder.Services.AddTransient<ModificarDocenteUseCase>();
builder.Services.AddTransient<ListarDocentesUseCase>();
builder.Services.AddScoped<IRepositorioDocente, RepositorioDocenteSQLite>();

//agregamos personas al contenedor DI
builder.Services.AddTransient<ListarPersonasUseCase>();
builder.Services.AddTransient<EncontrarPersonaUseCase>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersonaSQLite>();

//agregamos libros al contenedor DI
builder.Services.AddTransient<AltaLibroUseCase>();
builder.Services.AddTransient<BajaLibroUseCase>();
builder.Services.AddTransient<ModificarLibroUseCase>();
builder.Services.AddTransient<ListarLibrosUseCase>();
builder.Services.AddTransient<VerLibroUseCase>();
builder.Services.AddScoped<IRepositorioLibro, RepositorioLibroSQLite>();


//agregamos prestamos al contenedor DI
builder.Services.AddTransient<RealizarPrestamoUseCase>();
builder.Services.AddTransient<DevolverLibroUseCase>();
builder.Services.AddTransient<ListarPrestamosUseCase>();
builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamoSQLite>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
