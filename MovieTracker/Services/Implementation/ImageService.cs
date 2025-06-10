using MovieTracker.Settings;
using Microsoft.Extensions.Options;
using MovieTracker.Data;
using MovieTracker.Services.Interface;
using MovieTracker.Constants;

namespace MovieTracker.Services.Implementation
{
    public class ImageService : IImageService
    {
        //// ------ Inyección de dependencias del contexto de la base de datos -------
        //La inyección de dependencias permite que el servicio pueda acceder a la base de datos sin necesidad de crear una
        //instancia del contexto directamente.

        private readonly ApplicationDbContext _context; //Contexto de la base de datos
        private readonly UploadSettings _uploadSettings; //Configuración de carga de archivos
        private readonly IWebHostEnvironment _env; //Entorno web para acceder a la ruta del servidor

        public ImageService(ApplicationDbContext context, IOptions<UploadSettings> uploadSettings, IWebHostEnvironment env) //Constructor que recibe el contexto de la base de datos
        {
            _context = context;
            _uploadSettings = uploadSettings.Value; //Obtiene la configuración de carga de archivos desde las opciones inyectadas
            _env = env;
        }
        //------------------------------------------------------------------------

        //---------------- Implementación de sercicios ---------------- \\

        public async Task<string> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return string.Empty; // Si no hay archivo, retornar cadena vacía
            }

            ValidateFile(file);

            string _customPath = Path.Combine(_env.WebRootPath, _uploadSettings.UploadDirectory);

            if (!Directory.Exists(_customPath))   // Crear el directorio si no existe
            {
                Directory.CreateDirectory(_customPath);
            }

            // Generar el nombre único del archivo
            var fileName = Path.GetFileNameWithoutExtension(file.FileName)
                            + Guid.NewGuid().ToString()
                            + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_customPath, fileName);

            // Guardar el archivo
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Retornar la ruta relativa o completa, según sea necesario
            return $"/{_uploadSettings.UploadDirectory}/{fileName}";


        }

        private void ValidateFile(IFormFile file)
        {
            if (file == null) {
                return; // No file provided, skip validation
            }
            var permittedExtensions = _uploadSettings.AllowedExtensions.Split(',');
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!permittedExtensions.Contains(extension))
            {
                throw new NotSupportedException(Messages.Validation.UnSupportedFileType);
            }
        }

    }
}
