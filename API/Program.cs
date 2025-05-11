using AccesoDatos.ContextoEF;
using AccesoDatos.Repositorios;
using CasosUso.InterfacesCasosUso;
using LogicaAplicacion.CasosUso;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBuscarEnvio, BuscarEnvio>();
builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();

string strCon = builder.Configuration.GetConnectionString("MiConexion");
builder.Services.AddDbContext<GestionDeEnviosContext>(option => option.UseSqlServer(strCon));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
