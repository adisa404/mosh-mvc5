using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class MembershipType
	{
		public double SignUpFee { get; set; }

		public short Duration { get; set; }

		public short DiscountRate { get; set; }
	}
}