using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities.Cart
{
	public class PaymentMethod
	{

		[Key]
		public Guid ID { get; set; }=Guid.NewGuid();


		public string Name { get; set; }=string.Empty;
	}
}
