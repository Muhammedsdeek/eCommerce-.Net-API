using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Cart;
using eCommerce.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Interfaces.Cart
{
	public interface IcartService
	{
		Task<ServiceResponse> savCheckoutHistory(IEnumerable<CreateAchive> achives);

		Task<ServiceResponse> checkOut(CheckOut checkOut);	
	}
}
