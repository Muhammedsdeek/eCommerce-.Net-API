using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.DTOs
{
	public record  LoginResponse(
		
		bool success=false,
		string message=null!,
		string Token=null!,
		string RefreshToken=null!);
	
}
