using eCommerce._Application.Services.Interfaces.Cart;
using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Intefaces.Cart;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositries.Cart
{
	public class paymentMethodREpositry(AppDbContext context) : IpaymentMethods
	{
		public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
		{
		return 
				await context.PaymentMethods.AsNoTracking().ToListAsync();
		}
	}
}
