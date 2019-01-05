using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

		[HttpPost]
		public ActionResult Save(Customer customer)
		{
			// since the same action is used for saving and creating the customer
			// we first need to check if the id of customer is found in db
			// if not add

			if (customer.Id == 0)
			{
				_context.Customers.Add(customer);
			}
			else
			{
				var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.Birthdate = customer.Birthdate;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
				customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
			

			_context.SaveChanges();

			return RedirectToAction("Index", "Customer");
		}

		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();

			var viewModel = new CustomerFormViewModel()
			{
				MembershipTypes = membershipTypes
			};

			return View("CustomerForm", viewModel);
		}

		public ActionResult Details(int? id)
		{
			if (!id.HasValue) return HttpNotFound();

			var customer = _context
				.Customers
				.Where(c => c.Id == id)
				.Include(c => c.MembershipType)
				.FirstOrDefault();

			return View(customer);
		}

		public ActionResult Edit(int id)
		{
			var customer = _context
				.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null) return HttpNotFound();

			var viewModel = new CustomerFormViewModel()
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList() // initializing membership types from db
			};

			return View("CustomerForm", viewModel); // to tell MVC to search for the CustomerForm view
		}
	}
}