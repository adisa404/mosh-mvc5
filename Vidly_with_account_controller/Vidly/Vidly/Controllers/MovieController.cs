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

		

		public ActionResult Details(int id)
		{
			var movieById = _context
				.Movies
				.Include(m => m.Genres)
				.SingleOrDefault(m => m.Id == id);
			return View(movieById);
		}

		[Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(String.Format("{0}/{1}", year, month));
		}
	}
}