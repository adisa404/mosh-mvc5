using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		// GET: /api/movies
		public IEnumerable<MovieDto> GetMovies()
		{
			var movies = _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
			return movies;
		}

		// GET: /api/movies/id
		public MovieDto GetMovie(int id)
		{
			var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movie == null) throw new HttpResponseException(HttpStatusCode.NotFound);

			return Mapper.Map<Movie,MovieDto>(movie);
		}

		// POST: api/movies
		[HttpPost]
		public MovieDto CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			   _context.Movies.Add(movie);
			_context.SaveChanges();

			return movieDto;
		}

		// PUT: /api/movies/id
		[HttpPut]
		public void UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

			if(movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(movieInDb, movieDto);

			_context.SaveChanges();
		}

		// DELETE /api/movies/1
		[HttpDelete]
		public void DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movieInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();
		}
	}
}
