using tp4.Models;

namespace tp4.Services.ServiceContracts
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int id);
        void AddMovie(Movie Movie);
        void UpdateMovie(int id, Movie Movie);
        void DeleteMovie(int id);
        bool MoviesExists(int id);

        IEnumerable<Movie> GetMoviesOrderCroissantByName();
        IEnumerable<Movie> GetMoviesByGenreId(int id);
        IEnumerable<Genres> GetGenres();
    }
}