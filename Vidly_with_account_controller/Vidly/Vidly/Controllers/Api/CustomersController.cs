﻿using AutoMapper;
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
    public class CustomersController : ApiController
    {
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		// GET /api/customers
		public IHttpActionResult GetCustomers()
		{
			var customers = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
			return Ok(customers);
		}

		// GET /api/customers/1
		public IHttpActionResult GetCustomer(int id) 
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null) return BadRequest();

			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
		}

		// POST /api/customers
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

			_context.Customers.Add(customer);
			_context.SaveChanges();

			// after an Id is generated, we need to return the Id to the client
			customerDto.Id = customer.Id;

			//return Ok(customerDto);
			return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
		}

		// PUT /api/customers/1
		[HttpPut]
		public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(customerDto, customerInDb);

			_context.SaveChanges();
			return Ok();
		}

		//DELETE /api/customers/1

		[HttpDelete]
		public IHttpActionResult DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customerInDb == null)
				return NotFound();

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();

			return Ok();
		}
	}
}
