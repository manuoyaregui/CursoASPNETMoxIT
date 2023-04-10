using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new()
        {
            new Movie{Id = 0, Name = "Shrek!"},
            new Movie{Id = 1, Name = "Harry Potter"},
            new Movie{Id = 2, Name = "Lord of the Rings"},
            new Movie{Id = 3, Name = "John Wick"}
        };

        public IActionResult Index()
        {
            var viewModel = new AllMoviesViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var movie = movies[id];
            return View(movie);
        }

        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return Content("id" + id);
        }

        [Route("/movies/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}
