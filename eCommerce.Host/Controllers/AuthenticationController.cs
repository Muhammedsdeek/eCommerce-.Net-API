using eCommerce._Application.DTOs.Identity;
//using Microsoft.AspNetCore.Authentication;
using eCommerce._Application.Services.Interfaces.Authentication;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Host.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService authenticationService;

		public AuthenticationController(IAuthenticationService authenticationService)
		{
			this.authenticationService = authenticationService;
		}

		[HttpPost("Create")]

		public async Task<IActionResult> createuser(CreateUser createUser)
		{
			var result=
				await authenticationService.CareteUser(createUser);

			return result.Success
				? Ok(result)
				: BadRequest(result);

		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginUsr loginuser)
		{
			var result = await
				authenticationService.LoginUser(loginuser);

			return  result.success? Ok(result)
				: BadRequest(result);
		}


		[HttpGet("ReviveToken/{refreshtoken}")]
		public async Task<IActionResult> ReviveToken(string refreshtoken)
		{
			var result = await
				authenticationService.REviveToke(refreshtoken);

			return result.success ? Ok(result)
				: BadRequest(result);
		}



	}
}
