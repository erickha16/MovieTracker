using Microsoft.EntityFrameworkCore;

namespace MovieTracker.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        //Definir los modelos para que se creen en la base de datos
    }
}
