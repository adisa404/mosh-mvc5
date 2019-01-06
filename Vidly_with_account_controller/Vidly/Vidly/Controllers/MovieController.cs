using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MovieController : Controller
	{
		private ApplicationDbContext _context;

		public MovieController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Movies
		public ActionResult Index()
		{
			var movies =
				//get list of movies in Index view
				_context.Movies.Include(m => m.Genres).ToList();
			return View(movies);
		}

		public ActionResult New()
		{
			var viewModel = new MovieFormViewModel()
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
		{
			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.DateReleased = movie.DateReleased;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movie");
		}

		public ActionResult Details(int id)
		{
			var movieById = _context
				.Movies
				.Include(m => m.Genres)
				.SingleOrDefault(m => m.Id == id);
			return View(movieById);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movie == null) return HttpNotFound();

			var viewModel = new MovieFormViewModel()
			{
				Movie = movie,
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(String.Format("{0}/{1}", year, month));
		}
	}
}