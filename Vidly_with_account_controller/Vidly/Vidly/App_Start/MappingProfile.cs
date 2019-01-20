using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
	public class MappingProfile: Profile
	{
		public MappingProfile() {
			
			CreateMap<CustomerDto, Customer>();
			CreateMap<Customer, CustomerDto>()
				.ForMember(c => c.Id, opt => opt.Ignore());

			CreateMap<MovieDto, Movie>();
			CreateMap<Movie, MovieDto>()
			.ForMember(m => m.Id, opt => opt.Ignore());

			//CreateMap<Customer, CustomerDto>();
			//CreateMap<Movie, MovieDto>();
		}
	}
}