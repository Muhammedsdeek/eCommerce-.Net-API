using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Exceptions
{
	public class ItemNotFounException(string Message) : Exception(Message)
	{
	}
}
	