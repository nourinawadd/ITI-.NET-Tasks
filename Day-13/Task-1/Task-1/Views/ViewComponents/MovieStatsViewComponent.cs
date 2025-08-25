using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Models;

namespace Task_1.ViewComponents
{
    public class MovieStatsViewComponent : ViewComponent
    {
        private static readonly List<Movie> _movies = new()
        {
            new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010 },
            new Movie { Id = 2, Title = "Spirited Away", Director = "Hayao Miyazaki", ReleaseYear = 2001 },
            new Movie { Id = 3, Title = "Parasite", Director = "Bong Joon-ho", ReleaseYear = 2019 }
        };

        public IViewComponentResult Invoke()
        {
            var totalMovies = _movies.Count;
            var avgReleaseYear = totalMovies > 0 ? _movies.Average(m => m.ReleaseYear) : 0;

            var model = new MovieStatsViewModel
            {
                TotalMovies = totalMovies,
                AverageReleaseYear = avgReleaseYear
            };

            return View(model);
        }
    }
}
