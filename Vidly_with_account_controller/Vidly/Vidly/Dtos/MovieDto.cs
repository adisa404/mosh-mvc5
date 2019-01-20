using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
	public class MovieDto
	{

		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public Genre Genres { get; set; }

		[Required]
		public int GenreId { get; set; }
		public DateTime DateAdded { get; set; }

		[Required]
		public DateTime DateReleased
		{
			get
			{
				return new DateTime();
			}
			set { }
		}

		[Required]
		[Range(1, 20)]
		public int NumberInStock { get; set; }
	}
}