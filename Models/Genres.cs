namespace tp4.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string? GenreName { get; set; }

        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
