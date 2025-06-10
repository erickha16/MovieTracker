namespace MovieTracker.Services.Interface
{
    public interface IImageService
    {

        // ------Método para cargar la imagen
       Task<string> UploadImage(IFormFile file);

    }
}
