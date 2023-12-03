using System.ComponentModel.DataAnnotations.Schema;

namespace tp4.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Role>? Roles { get; set; }

        public DateTime? Movie_Added { get; set; }
        
        public int? genre_id { get; set; }

        public byte[]? file { get; set; }

        [ForeignKey("genre_id")]
        public virtual Genres? Genres { get; set; }


    }
}
