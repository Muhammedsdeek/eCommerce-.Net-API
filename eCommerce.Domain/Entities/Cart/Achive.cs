using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Entities.Cart
{
	public class Achive
	{

		[Key]	
		public Guid Id { get; set; }

		public Guid ProductId { get; set; }
		public int Quantity { get; set; }


		public Guid UserId	{ get; set; }

		public DateTime CreatedDate { get; set; }	=DateTime.Now;
	}
}
