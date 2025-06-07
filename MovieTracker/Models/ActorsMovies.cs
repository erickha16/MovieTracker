namespace MovieTracker.Models
{
    public class ActorsMovies:Registry
    {
        public int Id { get; set; }

        // Llaves foráneas
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
