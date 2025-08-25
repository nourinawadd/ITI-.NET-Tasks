using Microsoft.AspNetCore.Mvc;
using Task_1.Models;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        // in memory
        private static readonly List<Movie> _movies = new()
        {
            new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010 },
            new Movie { Id = 2, Title = "Spirited Away", Director = "Hayao Miyazaki", ReleaseYear = 2001 },
            new Movie { Id = 3, Title = "Parasite", Director = "Bong Joon-ho", ReleaseYear = 2019 }
        };

        // index
        public IActionResult Index()
        {
            return View(_movies);
        }

        // return json data for fetch api
        [HttpGet]
        public IActionResult GetMoviesJson()
        {
            var movies = _movies.Select(m => new
            {
                m.Id,
                m.Title,
                m.Director,
                m.ReleaseYear
            }).ToList();

            return Json(movies);

        }

        // test json ftch page
        public IActionResult TestJson()
        {
            return View();
        }

        // details
        public IActionResult Details(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }
    }
}
