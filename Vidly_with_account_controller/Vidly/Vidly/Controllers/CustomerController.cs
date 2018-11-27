using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
		private ApplicationDbContext _context;
		public CustomerController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Customer
		public ActionResult Index()
		{
			var customers = _context
				.Customers
				.Include(c => c.MembershipType).ToList();

			return View(customers);
		}

		public ActionResult Edit(int? id)
		{
			if (!id.HasValue) return HttpNotFound();

			var customer = _context
				.Customers
				.Where(c => c.Id == id)
				.Include(c => c.MembershipType)
				.FirstOrDefault();

			return View(customer);
		}
	}
}