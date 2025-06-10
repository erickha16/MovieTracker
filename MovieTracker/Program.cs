//Dar de alta servicios y configurar la aplicación ASP.NET Core MVC
using Microsoft.EntityFrameworkCore;
using MovieTracker.Data;
using MovieTracker.Services.Implementation;
using MovieTracker.Services.Interface;
using MovieTracker.Settings;

var builder = WebApplication.CreateBuilder(args);

// Se utiliza un operador de coalesencia, en caso de que no se encuentre la cadena de conexión, se lanza una excepción.
var connection = builder.Configuration.GetConnectionString("DbConnection") ?? 
    throw new InvalidOperationException("Connection string 'DbConnection' not found.");

// Configurar el contexto de la base de datos con Entity Framework Core y especificar el proveedor de base de datos SQL Server.
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(connection));

//Dar de salta Settings
builder.Services.Configure<UploadSettings>(builder.Configuration.GetSection("UploadSettings"));

//------------------------------ Agregar Servicios personalizados ------------------------------\\
// Servicio de imágenes
builder.Services.AddScoped<IImageService, ImageService>();

// Servicio de géneros
builder.Services.AddScoped<IGenreService, GenreService>();

// Servicio de plataformas
builder.Services.AddScoped<IPlatformService, PlatformService>();

//Servicio de Películas
builder.Services.AddScoped<IMovieService, MovieService>();

//Servicio de Series
builder.Services.AddScoped<ISerieService, SerieService>();





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
