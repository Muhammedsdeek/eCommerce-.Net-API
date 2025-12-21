using AutoMapper;
using eCommerce._Application.DTOs.Cart;
using eCommerce._Application.Services.Interfaces.Cart;
using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Intefaces.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Implementations.Cart
{
	public class PaymentMethodservice(IpaymentMethods paymentMethod,IMapper mapper) : IpaymentMethodService
	{
		public async Task< IEnumerable< GetPaymentMethod>> GetPaymentMethod()
		{
			var methods=await
				paymentMethod.GetPaymentMethods();

			if (!methods.Any())
				return [];

			return mapper.Map<IEnumerable< GetPaymentMethod>>(methods);

		}
	}
}
