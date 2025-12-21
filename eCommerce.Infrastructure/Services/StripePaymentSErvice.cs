using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Cart;
using eCommerce._Application.Services.Interfaces.Cart;
using eCommerce.Domain.Entities;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Services
{
	public class StripePaymentSErvice : IpaymentService
	{
		public async Task<ServiceResponse> pay(decimal totalAmount, IEnumerable<Product> cartPRoducts, IEnumerable<PRocessCart> carts)
		{

			try
			{
				var lineItems =

				   new List<SessionLineItemOptions>();

				foreach (var cart in cartPRoducts)
				{


					var pQuantity = carts.FirstOrDefault(c => c.ProductID == cart.Id);

					lineItems.Add(new SessionLineItemOptions
					{
						PriceData = new SessionLineItemPriceDataOptions
						{
							Currency = "usd",
							ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = cart.Name,
								Description = cart.Description,
								
							},
							UnitAmount = (long)(cart.Price * 100),
						},
						Quantity = pQuantity!.Quantity,
					});

				
				}
				var options = new SessionCreateOptions
				{
					PaymentMethodTypes = ["usd"],
					LineItems = lineItems,
					Mode = "payment",
					SuccessUrl = "https:localhost:7025/payment-success",
					CancelUrl = "https:localhost:7025/payment-cancel",
				};

				var service = new SessionService();

				Session session = await service.CreateAsync(options);

				return new ServiceResponse
				{
					Success = true,
					message = session.Url!,
				};
			}
			catch (Exception ex) { 

				return new ServiceResponse
				{
					Success = false,
					message = ex.Message,
				};
			}
		}
	}
}
