using Microsoft.AspNetCore.Mvc;
using Task_1.Models;
using System.Collections.Generic;
using System.Linq;

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
            var count = _movies.Count;
            var avgYear = _movies.Any() ? (int)_movies.Average(m => m.ReleaseYear) : 0;

            ViewBag.MovieCount = count;
            ViewBag.AvgYear = avgYear;

            return View();
        }
    }
}
