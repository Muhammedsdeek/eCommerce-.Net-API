using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Cart;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Interfaces.Cart
{
	public interface IpaymentService
	{


		Task<ServiceResponse >pay( decimal totalAmount, IEnumerable<Product> cartPRoducts,IEnumerable<PRocessCart> carts);
	}
}
