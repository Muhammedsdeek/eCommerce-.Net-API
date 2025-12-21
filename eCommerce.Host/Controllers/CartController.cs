using eCommerce._Application.DTOs.Cart;
using eCommerce._Application.Services.Interfaces.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Host.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController(IcartService cartService) : ControllerBase
	{



		[HttpPost("checkout")]

		public async Task<IActionResult> CheckOut(CheckOut checkOut)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var Result = await cartService.checkOut(checkOut);

			return Result.Success ? Ok(Result) : BadRequest(Result);


		}

		[HttpPost("saveCheckoutHistory")]
		public async Task<IActionResult> savCheckoutHistory(IEnumerable<CreateAchive> achives)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var Result = await cartService.savCheckoutHistory(achives);
			return Result.Success ? Ok(Result) : BadRequest(Result);

		}
	}
}
