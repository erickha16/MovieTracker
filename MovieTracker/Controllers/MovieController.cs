using Microsoft.AspNetCore.Mvc;
using MovieTracker.Constants;
using MovieTracker.Services.Interface;

namespace MovieTracker.Controllers
{
    public class MovieController : Controller
    {

        //---------------  Inyección de dependencias del servicio de películas ---------------\\
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //-------------------------------------------------------------------------------------\\
        // --------------------------------------  Mostrar lista de películas -------------------------------------- \\
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllAsync(); //Obtiene todas las marcas de forma asíncrona
            return View(movies);
        }

        // --------------------------------------  Acción para ver los detalles de una película -------------------------------------- \\
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var movie = await _movieService.GetByIdAsync(id); //Obtiene la película por ID de forma asíncrona
                return View(movie);
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.MovieNotFound;
                return RedirectToAction("Index"); //Redirige a la lista de películas si no se encuentra la película
            }
        }

        //Crear una nueva película
    }
}
