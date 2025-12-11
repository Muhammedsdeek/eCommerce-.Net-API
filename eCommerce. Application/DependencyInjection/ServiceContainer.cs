using eCommerce._Application.Mapping;
using eCommerce._Application.Services.Implementations;
using eCommerce._Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.DependencyInjection
{
	public static class ServiceContainer
	{

		public static IServiceCollection AddApplicationService(this IServiceCollection services)
		{

		
			services.AddAutoMapper(typeof(MappingConfig));
			services.AddScoped<ICategoryService, CategoryService>();

			services.AddScoped<IproductService, ProductService>();
			return services;
		}
	
	}
}
