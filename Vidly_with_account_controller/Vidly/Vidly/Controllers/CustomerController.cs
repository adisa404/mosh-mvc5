using System;
using System.Collections.Generic;
using System.Linq;
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
			var customers = _context.Customers.ToList();

			return View(customers);
		}

		public ActionResult Edit(int? id)
		{
			if (!id.HasValue) return HttpNotFound();

			var customer = GetCustomers().Where(c => c.Id == id).FirstOrDefault();
			return View(customer);
		}

		private IEnumerable<Customer> GetCustomers()
		{
			return new List<Customer>() {
				new Customer { Name = "Customer 1", Id = 1},
				new Customer { Name = "Customer 2", Id = 2}
			};
		}
	}
}