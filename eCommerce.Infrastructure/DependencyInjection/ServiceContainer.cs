using eCommerce.Domain.Entities;
using eCommerce.Domain.Intefaces;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.Repositries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DependencyInjection
{
	public static class ServiceContainer
	{

		 public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration Config)
		{
			string ConnectionString = Config.GetConnectionString("CS");

			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					ConnectionString,
					sqloptions =>
					{

						sqloptions.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
						sqloptions.EnableRetryOnFailure();

					}),
				ServiceLifetime.Scoped
			);
			services.AddScoped<Igeneric<Product>, GenericRepositry<Product>>();
			services.AddScoped<Igeneric<Category>, GenericRepositry<Category>>();

			return services;
		}
	}
}
