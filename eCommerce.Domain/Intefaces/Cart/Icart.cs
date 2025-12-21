using eCommerce.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Domain.Intefaces.Cart
{
	public interface Icart
	{

		Task<int> savCheckoutHistory(IEnumerable<Achive> achives);

	}
}
