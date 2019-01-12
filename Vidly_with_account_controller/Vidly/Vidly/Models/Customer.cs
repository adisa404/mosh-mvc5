using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		public DateTime? Birthdate { get; set; }

		// navigation property 
		// used when you wnat to load both customer and membership type from db
		public MembershipType MembershipType { get; set; }

		// foreign key
		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; } 
	}
}