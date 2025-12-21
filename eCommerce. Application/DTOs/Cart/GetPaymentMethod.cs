using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.DTOs.Cart
{
	public class GetPaymentMethod
	{

		public  required Guid ID { get; set; }


		public required string Name { get; set; }
	}
}
