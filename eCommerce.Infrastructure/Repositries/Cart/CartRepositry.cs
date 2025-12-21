using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Intefaces.Cart;
using eCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositries.Cart
{
	public class CartRepositry(AppDbContext context): Icart
	{
		public async Task<int> savCheckoutHistory(IEnumerable<Achive> achives)
		{
			await context.Achives.AddRangeAsync(achives);
			return await context.SaveChangesAsync();
		}
	}
}
