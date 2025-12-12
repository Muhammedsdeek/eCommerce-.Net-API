using eCommerce._Application.Services.Interfaces.Logging;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Intefaces;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.MIddleware;
using eCommerce.Infrastructure.Repositries;
using eCommerce.Infrastructure.Services;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

					}).UseExceptionProcessor(),
				ServiceLifetime.Scoped
			);
			services.AddScoped<Igeneric<Product>, GenericRepositry<Product>>();
			services.AddScoped<Igeneric<Category>, GenericRepositry<Category>>();
			services.AddScoped(typeof(IAppLOgger<>),typeof(SerilogLoggerAdapter<>));
			

			return services;
		}

		public static IApplicationBuilder UseInfrastructureService(this IApplicationBuilder app)
		{

			app.UseMiddleware<ExceptionHandelingMiddleware>();

			return app;


		}
	}
}
