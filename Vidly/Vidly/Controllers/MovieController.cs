using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
			var movies = GetMovies();
			return View(movies);
        }

		// GET: Movies/Random
		public ActionResult Random()
		{
			var movie = new Movie() { Name = "Harry Potter!" };

			var customers = new List<Customer>() {
				new Customer { Name = "Customer 1" },
				new Customer { Name = "Customer 2" }
			};

			var viewModel = new RandomMovieViewModel() { Customers = customers, Movie = movie };
		    return View(viewModel);
			//return Content("text");
			//return HttpNotFound();
			//return new EmptyResult(); // prazna stranica
			//return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
		}

		public ActionResult Edit(int id)
		{
			return View();
			// Content("id=" + id);
		}

		[Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(String.Format("{0}/{1}", year, month));
		}

		private IEnumerable<Movie> GetMovies()
		{
			return new List<Movie>() {
				new Movie {Name = "Harry Potter" },
				new Movie { Name = "Shrek"}
			};
		}
	}
}