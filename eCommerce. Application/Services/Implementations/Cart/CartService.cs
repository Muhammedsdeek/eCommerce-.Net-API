using AutoMapper;
using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Cart;
using eCommerce._Application.Services.Interfaces.Cart;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Cart;
using eCommerce.Domain.Intefaces;
using eCommerce.Domain.Intefaces.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Implementations.Cart
{
	public class CartService(IpaymentService paymentService,Icart cartinterfacse,IMapper mapper ,Igeneric<Product> productInterfacse,IpaymentMethodService paymentMethodService) : IcartService
	{
		public async Task<ServiceResponse> checkOut(CheckOut checkOut)
		{
			
			var (products,totalAmaunt)=	 await GetTotalAmaount(checkOut.Carts);
			var paymentMethod= await paymentMethodService.GetPaymentMethod();

			if (checkOut.PaymentMethod == paymentMethod.FirstOrDefault().ID)
				return await paymentService.pay(totalAmaunt,  products,checkOut.Carts);
			else
				return new ServiceResponse(false, "invalid payment method");

		}

		public async Task<ServiceResponse> savCheckoutHistory(IEnumerable<CreateAchive> achives)
		{
			var mappeddata=mapper.Map<IEnumerable<Achive>>(achives);
			var result=	 await cartinterfacse.savCheckoutHistory(mappeddata);
			return result > 0? new ServiceResponse(true,"saved successfully"):new ServiceResponse(false,"failed to save");
		}
		private async Task<(IEnumerable<Product>,decimal)>GetTotalAmaount(IEnumerable<PRocessCart> carts)
		{


			if (!carts.Any())
				return ([],0m);

			var products =
				await productInterfacse.GetAllAsync();
			if(!products.Any())
				return ([],0m);	

			var cartproducts=
				carts
				.Select(item=> products.FirstOrDefault(p=>p.Id==item.ProductID))
				.Where(p=>p is not null)
				.ToList();

			var totalAmaunt=
				carts
				.Where(carItem=> cartproducts.Any(p=>p.Id==carItem.ProductID))
				.Sum(carItem=> carItem.Quantity * cartproducts.First(p=>p!.Id==carItem.ProductID)!.Price);	

			return (cartproducts!, totalAmaunt);




		}
	}
}
