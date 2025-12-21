using eCommerce._Application.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Interfaces.Cart
{
	public interface IpaymentMethodService
	{
		Task<IEnumerable< GetPaymentMethod>> GetPaymentMethod();
	}	
}
