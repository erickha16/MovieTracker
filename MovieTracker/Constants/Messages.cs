namespace MovieTracker.Constants
{
    public class Messages
    {
        public static class Success
        {
            // Creación
            public const string GenreCreated = "Género agregado exitosamente";
            public const string PlatformCreated = "Plataforma agregada exitosamente";
            public const string ActorCreated = "Actor agregado exitosamente";
            public const string MovieCreated = "Película agregada exitosamente";
            public const string SerieCreated = "Serie agregada exitosamente";
            public const string RatingCreated = "Calificación agregada exitosamente";

            // Actualización
            public const string GenreUpdated = "Género actualizado exitosamente";
            public const string PlatformUpdated = "Plataforma actualizada exitosamente";
            public const string ActorUpdated = "Actor actualizado exitosamente";
            public const string MovieUpdated = "Película actualizada exitosamente";
            public const string SerieUpdated = "Serie actualizada exitosamente";
            public const string RatingUpdated = "Calificación actualizada exitosamente";

            // Eliminación
            public const string GenreDeleted = "Género eliminado exitosamente";
            public const string PlatformDeleted = "Plataforma eliminada exitosamente";
            public const string ActorDeleted = "Actor eliminado exitosamente";
            public const string MovieDeleted = "Película eliminada exitosamente";
            public const string SerieDeleted = "Serie eliminada exitosamente";
            public const string RatingDeleted = "Calificación eliminada exitosamente";
        }

        public static class Error
        {
            // Búsqueda/Existencia
            public const string GenreNotFound = "Género no encontrado";
            public const string PlatformNotFound = "Plataforma no encontrada";
            public const string ActorNotFound = "Actor no encontrado";
            public const string MovieNotFound = "Película no encontrada";
            public const string SerieNotFound = "Serie no encontrada";
            public const string RatingNotFound = "Calificación no encontrada";
            public const string GenreNotFoundWithId = "Género con ID {0} no encontrado";
            public const string PlatformNotFoundWithId = "Plataforma con ID {0} no encontrada";
            public const string ActorNotFoundWithId = "Actor con ID {0} no encontrado";
            public const string MovieNotFoundWithId = "Película con ID {0} no encontrada";
            public const string SerieNotFoundWithId = "Serie con ID {0} no encontrada";
            public const string RatingNotFoundWithId = "Calificación con ID {0} no encontrada";

            // Creación
            public const string GenreCreateError = "Hubo un error al agregar el género";
            public const string PlatformCreateError = "Hubo un error al agregar la plataforma";
            public const string ActorCreateError = "Hubo un error al agregar el actor";
            public const string MovieCreateError = "Hubo un error al agregar la película";
            public const string SerieCreateError = "Hubo un error al agregar la serie";
            public const string RatingCreateError = "Hubo un error al agregar la calificación";

            // Actualización
            public const string GenreUpdateError = "Error al actualizar el género";
            public const string PlatformUpdateError = "Error al actualizar la plataforma";
            public const string ActorUpdateError = "Error al actualizar el actor";
            public const string MovieUpdateError = "Error al actualizar la película";
            public const string SerieUpdateError = "Error al actualizar la serie";
            public const string RatingUpdateError = "Error al actualizar la calificación";

            // Eliminación
            public const string GenreDeleteError = "Error al eliminar el género";
            public const string PlatformDeleteError = "Error al eliminar la plataforma";
            public const string ActorDeleteError = "Error al eliminar el actor";
            public const string MovieDeleteError = "Error al eliminar la película";
            public const string SerieDeleteError = "Error al eliminar la serie";
            public const string RatingDeleteError = "Error al eliminar la calificación";
            public const string GenreCannotBeDeleted = "No se puede eliminar el género porque tiene referencias";
            public const string PlatformCannotBeDeleted = "No se puede eliminar la plataforma porque tiene referencias";
            public const string ActorCannotBeDeleted = "No se puede eliminar el actor porque tiene referencias";
            public const string MovieCannotBeDeleted = "No se puede eliminar la película porque tiene referencias";
            public const string SerieCannotBeDeleted = "No se puede eliminar la serie porque tiene referencias";
            public const string RatingCannotBeDeleted = "No se puede eliminar la calificación porque tiene referencias";

            //Existencia
            public const string GenreAlreadyExists = "El género ya existe";
            public const string PlatformAlreadyExists = "La plataforma ya existe";
            public const string ActorAlreadyExists = "El actor ya existe";
            public const string MovieAlreadyExists = "La película ya existe";
            public const string SerieAlreadyExists = "La serie ya existe";
            public const string RatingAlreadyExists = "La calificación ya existe";
        }

        public static class Validation
        {
            public const string UnSupportedFileType = "El tipo de archivo no es soportado.";
        }

        public static class Info
        {

        }
    }
}
