using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllAsync(); //Obtiene todas las marcas de forma asíncrona
            return View(movies);
        }
    }
}
