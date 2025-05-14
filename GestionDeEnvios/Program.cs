using AccesoDatos.ContextoEF;
using AccesoDatos.Repositorios;
using CasosUso.InterfacesCasosUso;
using LogicaAplicacion;
using LogicaAplicacion.CasosUso;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
builder.Services.AddScoped<IRepositorioRegistroAuditable, RepositorioRegistroAuditable>();
builder.Services.AddScoped<IRepositorioComentario, RepositorioComentario>();
builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();
builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<IListarUsuarios, ListarUsuarios>();
builder.Services.AddScoped<IListarVendedores, ListarVendedores>();
builder.Services.AddScoped<IListarClientes, ListarClientes>();
builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();
builder.Services.AddScoped<IBuscarUsuarioConContrasenia, BuscarUsuarioConContrasenia>();
builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
builder.Services.AddScoped<IBajaUsuario, BajaUsuario>();
builder.Services.AddScoped<IListarRoles, ListarRoles>();
builder.Services.AddScoped<IBuscarRol, BuscarRol>();
builder.Services.AddScoped<IListarAgencias, ListarAgencias>();
builder.Services.AddScoped<IBuscarAgencia, BuscarAgencia>();
builder.Services.AddScoped<IListarEnvios, ListarEnvios>();
builder.Services.AddScoped<IListarEnviosEnProceso, ListarEnviosEnProceso>();
builder.Services.AddScoped<IBuscarEnvio, BuscarEnvio>();
builder.Services.AddScoped<IAltaEnvio, AltaEnvio>();
builder.Services.AddScoped<IFinalizarEnvio, FinalizarEnvio>();
builder.Services.AddScoped<IAltaComentario, AltaComentario>();

string strCon = builder.Configuration.GetConnectionString("MiConexion");
builder.Services.AddDbContext<GestionDeEnviosContext>(option => option.UseSqlServer(strCon));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuarios}/{action=Login}/{id?}");

app.Run();
