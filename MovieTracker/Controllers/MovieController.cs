using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTracker.Constants;
using MovieTracker.DTOs;
using MovieTracker.Services.Interface;

namespace MovieTracker.Controllers
{
    public class MovieController : Controller
    {

        //---------------  Inyección de dependencias del servicio de películas ---------------\\
        private readonly IMovieService _movieService;
        //Añadimos el servicio de Géneros y Plataformas para poder usarlos en el controlador
        private readonly IGenreService _genreService;
        private readonly IPlatformService _platformService;

        public MovieController(IMovieService movieService, IGenreService genreService, IPlatformService platformService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _platformService = platformService;
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
        //GET
        public async Task<IActionResult> Create()
        {
            //Mandar la lista de géneros y plataformas al formulario de creación
            var genres = await _genreService.GetAllAsync(); //Obtiene la lista de géneros
            var platforms = await _platformService.GetAllAsync(); //Obtiene la lista de plataformas

            //Y las mandamos por ViewBag  en forma de selectList para que estén disponibles en la vista
            ViewBag.Genres = new SelectList(genres, "Id", "Name"); //Lista de géneros
            ViewBag.Platforms = new SelectList(platforms, "Id", "Name"); //Lista de plataformas

            return View(); //Devuelve la vista para crear una nueva película
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(MovieDTO movieDTO)
        {
            try
            {
                if (ModelState.IsValid) //Verifica si el modelo es válido
                {
                    await _movieService.AddAsync(movieDTO); //Agrega la nueva película de forma asíncrona
                    TempData["SuccessMessage"] = Messages.Success.MovieCreated; //Mensaje de éxito
                    return RedirectToAction("Index"); //Redirige a la lista de películas
                }
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.MovieCreateError;
            }

            //Si hay un error, vuelve a cargar las listas de géneros y plataformas
            var genres = await _genreService.GetAllAsync(); //Obtiene la lista de géneros
            var platforms = await _platformService.GetAllAsync(); //Obtiene la lista de plataformas

            ViewBag.Genres = new SelectList(genres, "Id", "Name"); //Lista de géneros
            ViewBag.Platforms = new SelectList(platforms, "Id", "Name"); //Lista de plataformas

            return View(movieDTO); //Devuelve la vista con el modelo de película para corregir errores
        }


        // --------------------------------------  Acción para editar una película -------------------------------------- \\
        //Edit (GET)
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var movie = await _movieService.GetByIdAsync(id); //Obtiene la película por ID de forma asíncrona

                //Mandar la lista de géneros y plataformas al formulario de edición
                var genres = await _genreService.GetAllAsync(); //Obtiene la lista de géneros
                var platforms = await _platformService.GetAllAsync(); //Obtiene la lista de plataformas

                //Y las mandamos por ViewBag  en forma de selectList para que estén disponibles en la vista
                ViewBag.Genres = new SelectList(genres, "Id", "Name", movie.GenreId); //Lista de géneros
                ViewBag.Platforms = new SelectList(platforms, "Id", "Name", movie.PlatformId); //Lista de plataformas

                return View(movie); //Devuelve la vista para editar una película
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.MovieNotFound;
                return RedirectToAction("Index"); //Redirige a la lista de películas si no se encuentra la película
            }
        }

        //Edit (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(MovieDTO movieDTO)
        {
            try
            {
                if (ModelState.IsValid) //Verifica si el modelo es válido
                {
                    await _movieService.UpdateAsync(movieDTO); //Actualiza la película de forma asíncrona
                    TempData["SuccessMessage"] = Messages.Success.MovieUpdated; //Mensaje de éxito
                    return RedirectToAction("Index"); //Redirige a la lista de películas
                }
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.MovieUpdateError;
            }

            //Si hay un error, vuelve a cargar las listas de géneros y plataformas
            var genres = await _genreService.GetAllAsync(); //Obtiene la lista de géneros
            var platforms = await _platformService.GetAllAsync(); //Obtiene la lista de plataformas

            ViewBag.Genres = new SelectList(genres, "Id", "Name", movieDTO.GenreId); //Lista de géneros
            ViewBag.Platforms = new SelectList(platforms, "Id", "Name", movieDTO.PlatformId); //Lista de plataformas

            return View(movieDTO); //Devuelve la vista con el modelo de película para corregir errores
        }

        // --------------------------------------  Acción para confirmar la eliminación -------------------------------------- \\
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var movie = await _movieService.GetByIdAsync(id); //Obtiene la película por ID de forma asíncrona
                return View(movie); //Devuelve la vista de confirmación de eliminación
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.MovieNotFound;
                return RedirectToAction("Index"); //Redirige a la lista de películas si no se encuentra la película
            }
        }

        //---------------------------- Acción para eliminar un producto ---------------------------------------- \\
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _movieService.DeleteAsync(id);
                TempData["SuccessMessage"] = Messages.Success.MovieDeleted;
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = Messages.Error.MovieDeleteError;
            }

            return RedirectToAction("Index");
        }
    }
}
