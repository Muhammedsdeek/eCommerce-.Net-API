using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.DTOs
{
	public record ServiceResponse(bool Success=false,string message=null!)
	
}
