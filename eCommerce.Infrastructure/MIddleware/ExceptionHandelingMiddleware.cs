using eCommerce._Application.Services.Interfaces.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.MIddleware
{
	public class ExceptionHandelingMiddleware(RequestDelegate _next)
	{

		
		public async Task InvokeAsync(HttpContext context)
		{


			try
			{

				await _next(context);

			}

			catch (DbUpdateException ex)
			{

				var logger = 
					context.RequestServices.GetRequiredService<IAppLOgger<ExceptionHandelingMiddleware>>();
				context.Response.ContentType = "application/json";
				var InnerException = ex.InnerException  as SqlException;
				if (InnerException != null)
				{
					logger.LogError(InnerException, "sql Exception");


					switch (InnerException.Number)
					{


						case 2627:
							context.Response.StatusCode = StatusCodes.Status409Conflict;
							await context.Response.WriteAsync("Uinqe Constraint violation");
							break;

						case 515:
							context.Response.StatusCode = StatusCodes.Status400BadRequest;
							await context.Response.WriteAsync("Cannot insert null ");
							break;


						case 547:
							context.Response.StatusCode = StatusCodes.Status409Conflict;
							await context.Response.WriteAsync("Foreign key constraint Violation");
							break;

							default:
							context.Response.StatusCode = StatusCodes.Status500InternalServerError;
							await context.Response.WriteAsync("An unexpected error occurred while processing your request.");
							break;
					}
				}
				else
				{
					logger.LogError(ex, "EfCore Exception");
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;
					await context.Response.WriteAsync("An unexpected error occurred while processing your request.");

				}
			}
			catch (Exception ex) {

				var logger =
					context.RequestServices.GetRequiredService<IAppLOgger<ExceptionHandelingMiddleware>>();
				logger.LogError(ex, "unkown exception");
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await context.Response.WriteAsync($"An Error occurred :{ex.Message}");
			}
			
		}
	}
}
