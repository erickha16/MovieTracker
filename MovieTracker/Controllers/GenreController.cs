using Microsoft.AspNetCore.Mvc;
using MovieTracker.Constants;
using MovieTracker.DTOs;
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


        //Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreDTO genreDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    await _genreService.AddAsync(genreDTO); // Llamada al servicio para agregar el género
                    TempData["SuccessMessage"] = Messages.Success.GenreCreated; // Mensaje de éxito
                    return RedirectToAction("Index"); // Redirigir a la lista de géneros
                }
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.GenreCreateError; // Mensaje de error genérico
            }

            return View(genreDTO);
        }


        //Edit (redirección)
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
               GenreDTO genreDTO = await _genreService.GetByIdAsync(id); // Llamada al servicio para obtener el género por ID
               return View(genreDTO); // Retornar la vista de edición con el género encontrado
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.GenreNotFound; // Mensaje de error si no se encuentra el género
                return RedirectToAction("Index"); // Redirigir a la lista de géneros
            }
        }

        //Editar
        [HttpPost]
        public async Task<IActionResult> Edit(GenreDTO genreDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _genreService.UpdateAsync(genreDTO); // Llamada al servicio para actualizar el género
                    TempData["SuccessMessage"] = Messages.Success.GenreUpdated; // Mensaje de éxito
                    return RedirectToAction("Index"); // Redirigir a la lista de géneros
                }
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.GenreUpdateError; // Mensaje de error genérico
            }
            return View(genreDTO); // Retornar la vista con el modelo actualizado
        }

        //Mostrar la confirmación de eliminación
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                GenreDTO genreDTO = await _genreService.GetByIdAsync(id); // Llamada al servicio para obtener el género por ID
                return View(genreDTO); // Retornar la vista de confirmación de eliminación con el género encontrado
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.GenreNotFound; // Mensaje de error si no se encuentra el género
                return RedirectToAction("Index"); // Redirigir a la lista de géneros
            }
        }

        //Eliminar
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _genreService.DeleteAsync(id); // Llamada al servicio para eliminar el género por ID
                TempData["SuccessMessage"] = Messages.Success.GenreDeleted;
            }
            catch
            {
                TempData["ErrorMessage"] = Messages.Error.GenreDeleteError;
            }

            return RedirectToAction("Index");
        }

    }
}
