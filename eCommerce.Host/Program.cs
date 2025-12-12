
using eCommerce.Infrastructure.DependencyInjection;
using eCommerce._Application.DependencyInjection;

using eCommerce.Infrastructure.DependencyInjection;
using Serilog;

namespace eCommerce.Host
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			builder.Host.UseSerilog();
			Log.Logger.Information("application is building...............");
			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services.AddCors(options =>
			{

				options.AddDefaultPolicy(policy =>
				{
					policy.AllowAnyHeader();
					policy.AllowAnyMethod();
					policy.AllowAnyOrigin();
				});
			});
			

			builder.Services.AddInfrastructureService(builder.Configuration);
			builder.Services.AddApplicationService();


			try {
				var app = builder.Build();
				app.UseCors();
				app.UseSerilogRequestLogging();
				// Configure the HTTP request pipeline.
				if (app.Environment.IsDevelopment())
				{
					app.UseSwagger();
					app.UseSwaggerUI();
				}

				app.UseInfrastructureService();
				app.UseHttpsRedirection();

				app.UseAuthorization();


				app.MapControllers();
				Log.Logger.Information("Application is running ........");
				app.Run();

			}

			catch (Exception ex) {


				Log.Logger.Error(ex, "Application fial to start.....");
			}

			finally
			{

				Log.CloseAndFlush();	

			}
		}
	}
}
