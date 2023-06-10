using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Aseguradora.UI.Data;
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddTransient<AgregarPolizaUseCase>();
builder.Services.AddTransient<AgregarSiniestroUseCase>();
builder.Services.AddTransient<AgregarTerceroUseCase>();
builder.Services.AddTransient<AgregarTitularUseCase>();
builder.Services.AddTransient<AgregarVehiculoUseCase>();

builder.Services.AddTransient<EliminarPolizaUseCase>();
builder.Services.AddTransient<ListarPolizasUseCase>();
builder.Services.AddTransient<ModificarPolizaUseCase>();

builder.Services.AddTransient<EliminarSiniestroUseCase>();
builder.Services.AddTransient<ListarSiniestrosUseCase>();
builder.Services.AddTransient<ModificarSiniestroUseCase>();

builder.Services.AddTransient<EliminarTerceroUseCase>();
builder.Services.AddTransient<ListarTercerosUseCase>();
builder.Services.AddTransient<ModificarTerceroUseCase>();

builder.Services.AddTransient<EliminarTitularUseCase>();
builder.Services.AddTransient<BuscarTitularUseCase>();
builder.Services.AddTransient<ListarTitularesUseCase>();
builder.Services.AddTransient<ModificarTitularUseCase>();

builder.Services.AddTransient<EliminarVehiculoUseCase>();
builder.Services.AddTransient<ListarVehiculosUseCase>();
builder.Services.AddTransient<ModificarVehiculoUseCase>();
builder.Services.AddTransient<ListarTitularesConSusVehiculosUseCase>();

builder.Services.AddScoped<IRepositorioTitular, RepositorioTitularSQL>();
builder.Services.AddScoped<IRepositorioTercero, RepositorioTerceroSQL>();
builder.Services.AddScoped<IRepositorioVehiculo, RepositorioVehiculoSQL>();
builder.Services.AddScoped<IRepositorioSiniestro, RepositorioSiniestroSQL>();
builder.Services.AddScoped<IRepositorioPoliza, RepositorioPolizaSQL>();

//inicializamos la base de datos
AseguradoraContext db = new AseguradoraContext();
db.Inicializar();

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
