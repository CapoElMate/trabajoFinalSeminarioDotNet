using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Biblioteca.UI.Data;

using Biblioteca.Aplicacion;
using Biblioteca.Repositorios;

var builder = WebApplication.CreateBuilder(args);

//inicio la bdd con algunos datos (metodos de debug):
var iniciarBdd = new IniciarBdd();
iniciarBdd.Ejecutar();

//agregamos estos servicios al contenedor DI
builder.Services.AddTransient<AltaEstudianteUseCase>();
builder.Services.AddTransient<BajaEstudianteUseCase>();
builder.Services.AddTransient<ModificarEstudianteUseCase>();
builder.Services.AddTransient<ListarEstudiantesUseCase>();
builder.Services.AddScoped<IRepositorioEstudiante, RepositorioEstudianteSQLite>();

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
