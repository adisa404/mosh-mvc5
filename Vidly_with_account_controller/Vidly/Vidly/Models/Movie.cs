using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[Required]
		public Genre Genres { get; set; }
		public int GenreId { get; set; }

		public DateTime DateAdded { get; set; }
		public DateTime DateReleased { get; set; }
		public int NumberInStock { get; set; }
	}
}