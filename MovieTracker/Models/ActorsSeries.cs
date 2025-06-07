namespace MovieTracker.Models
{
    public class ActorsSeries: Registry
    {
        public int Id { get; set; }

        // Llaves foráneas
        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
