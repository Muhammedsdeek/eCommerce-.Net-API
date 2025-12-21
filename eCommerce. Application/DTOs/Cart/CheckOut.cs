using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.DTOs.Cart
{
	public class CheckOut
	{
		[Required]
		public required Guid PaymentMethod { get; set; }

		[Required]
		public required IEnumerable<PRocessCart> Carts { get; set; }
	}
}
