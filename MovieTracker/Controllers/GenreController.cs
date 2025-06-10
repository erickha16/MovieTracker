using Microsoft.AspNetCore.Mvc;
using MovieTracker.Services.Interface;

namespace MovieTracker.Controllers
{
    public class GenreController : Controller
    {
        //---------------  Inyección de dependencias del servicio de géneros ---------------\\
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        //-------------------------------------------------------------------------------------\\

        public IActionResult Index()
        {
            var genres = _genreService.GetAllAsync().Result; // Llamada al servicio para obtener todos los géneros
            return View(genres);
        }
    }
}
