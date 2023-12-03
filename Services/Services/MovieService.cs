using Microsoft.EntityFrameworkCore;
using tp4.Data;
using tp4.Models;
using tp4.Services.ServiceContracts;

namespace tp4.Services.Services
{
    public class MoviesService : IMovieService
    {
        private readonly ApplicationdbContext _db;
        public MoviesService(ApplicationdbContext db)
        {
            _db = db;
        }

        public List<Movie> GetMovies()
        {
            return _db.movies.Include(m => m.Genres).ToList();
        }

        public void AddMovie(Movie Movie)
        {
            _db.movies.Add(Movie);
            _db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            Movie Movie = _db.movies.Find(id);

            if (Movie == null)
            {
                return;
            }
            _db.movies.Remove(Movie);
            _db.SaveChanges();
        }

        public IEnumerable<Movie> GetMoviesByGenreId(int id)
        {
            return _db.movies.Include(m => m.Genres).Where(Movie => Movie.genre_id == id);
        }

        public IEnumerable<Movie> GetMoviesOrderCroissantByName()
        {

            return _db.movies.Include(m => m.Genres).OrderBy(Movie => Movie.Name);
        }



        public IEnumerable<Genres> GetGenres()
        {
            return _db.genres.ToList();
        }


        public Movie GetMovieById(int id)
        {
            return _db.movies
                            .Include(m => m.Genres)
                            .FirstOrDefault(m => m.Id == id);
        }

        public void UpdateMovie(int id, Movie Movie)
        {
            try
            {
                _db.Update(Movie);
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.movies.Any(m => m.Id == id))
                {
                    throw new Exception("Movie not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public bool MoviesExists(int id)
        {
            return (_db.movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
