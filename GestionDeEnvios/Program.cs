using AccesoDatos.Repositorios;
using CasosUso.InterfacesCasosUso;
using LogicaAplicacion.CasosUso;
using LogicaNegocio.InterfacesRepositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
builder.Services.AddScoped<IRepositorioRegistroAuditable, RepositorioRegistroAuditable>();
builder.Services.AddScoped<IRepositorioComentario, RepositorioComentario>();
builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<IListarUsuarios, ListarUsuarios>();
builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();
builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
builder.Services.AddScoped<IListarRoles, ListarRoles>();
builder.Services.AddScoped<IBuscarRol, BuscarRol>();

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
