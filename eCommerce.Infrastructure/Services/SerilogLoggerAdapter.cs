using eCommerce._Application.Services.Interfaces.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
{
	public class SerilogLoggerAdapter<T>(ILogger<T> logger) : IAppLOgger<T>
	{
		public void LogError(Exception ex, string message) => logger.LogError(ex, message);

		public void LoginInformation(string message) => logger.LogInformation(message);

		public void LogWarning(string message) => logger.LogWarning(message);
	}
}
