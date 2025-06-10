using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieTracker.Constants;
using MovieTracker.DTOs;
using MovieTracker.Services.Implementation;
using MovieTracker.Services.Interface;

namespace MovieTracker.Controllers
{
    public class SerieController : Controller
    {
        //---------------  Inyección de dependencias del servicio de series ---------------\\
        private readonly ISerieService _serieService;

        //Añadimos el servicio de Géneros y Plataformas para poder usarlos en el controlador
        private readonly IGenreService _genreService;
        private readonly IPlatformService _platformService;

        public SerieController(ISerieService serieService, IGenreService genreService, IPlatformService platformService)
        {
            _serieService = serieService;
            _genreService = genreService;
            _platformService = platformService;
        }

        //-------------------------------------------------------------------------------------\\

        // --------------------------------------  Mostrar lista de series -------------------------------------- \\
        public async Task<IActionResult> Index()
        {
            var series = await _serieService.GetAllAsync();
            return View(series);
        }

        // --------------------------------------  Acción para ver los detalles de una serie -------------------------------------- \\

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var serie = await _serieService.GetByIdAsync(id); //Obtiene la serie por ID de forma asíncrona
                return View(serie);
            }
            catch
            {
                TempData["ErrorMessage"] = "Serie no encontrada."; // Mensaje de error si no se encuentra la serie
                return RedirectToAction("Index"); //Redirige a la lista de series si no se encuentra la serie
            }
        }

        // ---------------------------------------- Crear una nueva serie ---------------------------------------- \\
        //GET
        public async Task<IActionResult> Create()
        {
            //Mandar la lista de géneros y plataformas al formulario de creación
            var genres = await _genreService.GetAllAsync(); //Obtiene la lista de géneros
            var platforms = await _platformService.GetAllAsync(); //Obtiene la lista de plataformas

            //Y las mandamos por ViewBag  en forma de selectList para que estén disponibles en la vista
            ViewBag.Genres = new SelectList(genres, "Id", "Name"); //Lista de géneros
            ViewBag.Platforms = new SelectList(platforms, "Id", "Name"); //Lista de plataformas

            return View(); //Devuelve la vista para crear una nueva serie
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(SerieDTO serieDTO)
        {
            try
            {
                if (ModelState.IsValid) //Verifica si el modelo es válido
                {
                    await _serieService.AddAsync(serieDTO); //Agrega la nueva serie de forma asíncrona
                    TempData["SuccessMessage"] = Messages.Success.SerieCreated; //Mensaje de éxito
                    return RedirectToAction("Index"); //Redirige a la lista de series
                }
            }
            catch
            {
                TempData["SuccessMessage"] = Messages.Error.SerieCreateError;
            }

            //Si el modelo no es válido, vuelve a mostrar el formulario con los datos ingresados
            var genres = await _genreService.GetAllAsync();
            var platforms = await _platformService.GetAllAsync();

            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            ViewBag.Platforms = new SelectList(platforms, "Id", "Name");

            return View(serieDTO);
        }



        // ---------------------------------------- Editar una serie ---------------------------------------- \\
        //GET
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var serie = await _serieService.GetByIdAsync(id); //Obtiene la serie por ID de forma asíncrona

                //Mandar la lista de géneros y plataformas al formulario de edición
                var genres = await _genreService.GetAllAsync(); //Obtiene la lista de géneros
                var platforms = await _platformService.GetAllAsync(); //Obtiene la lista de plataformas

                //Y las mandamos por ViewBag  en forma de selectList para que estén disponibles en la vista
                ViewBag.Genres = new SelectList(genres, "Id", "Name", serie.GenreId); //Lista de géneros con el género seleccionado
                ViewBag.Platforms = new SelectList(platforms, "Id", "Name", serie.PlatformId); //Lista de plataformas con la plataforma seleccionada

                return View(serie); //Devuelve la vista para editar una serie
            }
            catch
            {
                TempData["ErrorMessage"] = "Error al cargar los datos de la serie."; // Mensaje de error si ocurre un problema al cargar los datos
                return RedirectToAction("Index"); //Redirige a la lista de series si ocurre un error
            }
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit(SerieDTO serieDTO)
        {
            try
            {
                if (ModelState.IsValid) //Verifica si el modelo es válido
                {
                    await _serieService.UpdateAsync(serieDTO); //Actualiza la serie de forma asíncrona
                    TempData["SuccessMessage"] = Messages.Success.SerieUpdated; //Mensaje de éxito
                    return RedirectToAction("Index"); //Redirige a la lista de series
                }
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.SerieUpdateError; // Mensaje de error si ocurre un problema al actualizar la serie
            }
            //Si el modelo no es válido, vuelve a mostrar el formulario con los datos ingresados
            var genres = await _genreService.GetAllAsync();
            var platforms = await _platformService.GetAllAsync();

            ViewBag.Genres = new SelectList(genres, "Id", "Name", serieDTO.GenreId);
            ViewBag.Platforms = new SelectList(platforms, "Id", "Name", serieDTO.PlatformId);

            return View(serieDTO);
        }

        // --------------------------------------  Acción para confirmar la eliminación -------------------------------------- \\
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var serie = await _serieService.GetByIdAsync(id); //Obtiene la serie por ID de forma asíncrona
                return View(serie); //Devuelve la vista de confirmación de eliminación
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.MovieNotFound;
                return RedirectToAction("Index"); //Redirige a la lista de series si no se encuentra la película
            }
        }

        //---------------------------- Acción para eliminar un producto ---------------------------------------- \\
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serieService.DeleteAsync(id);
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

