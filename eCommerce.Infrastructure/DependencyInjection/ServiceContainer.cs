using eCommerce._Application.Services.Interfaces.Logging;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Intefaces;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.MIddleware;
using eCommerce.Infrastructure.Repositries;
using eCommerce.Infrastructure.Services;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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


			services.AddDefaultIdentity<AppUser>(options =>
			{

				options.SignIn.RequireConfirmedEmail = true;

				options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;


				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = true;

				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;

				options.Password.RequiredUniqueChars = 1;


			})
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();


			services.AddAuthentication(options =>
			{

				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options => {


					options.SaveToken = true;
					options.TokenValidationParameters =
					new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
					{
						ValidateAudience = true,
						ValidateIssuer = true,
						ValidateLifetime = true,
						RequireExpirationTime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Config["JWT:Issuer"],
						ValidAudience = Config["JWT:Audience"],
						ClockSkew = TimeSpan.Zero,
						IssuerSigningKey =
						new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["JWT:key"]!))
					};
				})
				;
			return services;
		}

		public static IApplicationBuilder UseInfrastructureService(this IApplicationBuilder app)
		{

			app.UseMiddleware<ExceptionHandelingMiddleware>();

			return app;


		}
	}
}
