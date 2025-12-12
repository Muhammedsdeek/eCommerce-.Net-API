using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Interfaces.Logging
{
	public interface IAppLOgger<T>
	{
		void LoginInformation(string message);

		void LogWarning(string message);

		void LogError(Exception ex, string message);
	}
}
