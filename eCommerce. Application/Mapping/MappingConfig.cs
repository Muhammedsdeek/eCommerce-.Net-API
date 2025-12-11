using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce._Application.DTOs.Category;
using eCommerce._Application.DTOs.Product;
using eCommerce.Domain.Entities;

namespace eCommerce._Application.Mapping
{
	public class MappingConfig : Profile
	{

		public MappingConfig()
		{
			CreateMap<CreateProduct, Product>();
			CreateMap<CreateCategory, Category>();

			CreateMap<Category, GetCategory>();
			CreateMap<Product, GetProduct>();

		}

	}
}
