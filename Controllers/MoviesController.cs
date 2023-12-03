using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp4.Models;
using tp4.Services.ServiceContracts;


namespace tp4.Controllers
{
    public class MoviesController : Controller
    {

        //inject the IMovieService
        private readonly IMovieService _MoviesService;
        public MoviesController(IMovieService MoviesService)
        {
            _MoviesService = MoviesService;
        }


        public IActionResult Index()
        {
            var Movies = _MoviesService.GetMovies();
            return View(Movies);
        }


        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var movies = _MoviesService.GetMovieById(id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["genre_id"] = new SelectList(_MoviesService.GetGenres(), "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Movie_Added,genre_id")] Movie movies, IFormFile file)
        {
            Console.WriteLine("MMMMMMMMM");
            Console.WriteLine(file);
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {

                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);

                        movies.file = memoryStream.ToArray();
                    }

                }
                _MoviesService.AddMovie(movies);
                return RedirectToAction(nameof(Index));
            }
            ViewData["genre_id"] = new SelectList(_MoviesService.GetGenres(), "Id", "Id", movies.genre_id);
            return View(movies);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = _MoviesService.GetMovieById(id);
            if (movies == null)
            {
                return NotFound();
            }
            ViewData["genre_id"] = new SelectList(_MoviesService.GetGenres(), "Id", "Id", movies.genre_id);
            return View(movies);
        }


        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movies)
        {
            if (id != movies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _MoviesService.UpdateMovie(id, movies);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return View(movies);

                }
            }

            ViewData["genre_id"] = new SelectList(_MoviesService.GetGenres(), "Id", "Id", movies.genre_id);
            return View(movies);
        }


        [HttpGet]
        [Route("Movies/ordered")]
        public IActionResult Ordered()
        {

            var movies = _MoviesService.GetMoviesOrderCroissantByName();
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }



        // GET: Movies/Role/5
        public IActionResult Genre(int id)
        {
            var movies = _MoviesService.GetMoviesByGenreId(id);
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = _MoviesService.GetMovieById(id);
            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movies = _MoviesService.GetMovieById(id);
            if (movies != null)
            {
                _MoviesService.DeleteMovie(id);
            }


            return RedirectToAction(nameof(Index));
        }



    }
}
