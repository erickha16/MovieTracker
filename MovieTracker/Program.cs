//Dar de alta servicios y configurar la aplicación ASP.NET Core MVC
using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;

var builder = WebApplication.CreateBuilder(args);

// Se utiliza un operador de coalesencia, en caso de que no se encuentre la cadena de conexión, se lanza una excepción.
var connection = builder.Configuration.GetConnectionString("DbConnection") ?? 
    throw new InvalidOperationException("Connection string 'DbConnection' not found.");

// Configurar el contexto de la base de datos con Entity Framework Core y especificar el proveedor de base de datos SQL Server.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

//------------------------------ Agregar Servicios personalizados ------------------------------\\

















// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
