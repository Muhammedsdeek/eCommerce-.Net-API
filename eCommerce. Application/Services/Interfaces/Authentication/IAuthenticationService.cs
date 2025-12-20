using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Interfaces.Authentication
{
	public interface IAuthenticationService
	{
		 Task<ServiceResponse> CareteUser(CreateUser User);
		 Task<LoginResponse> LoginUser(LoginUsr User);
		 Task<LoginResponse> REviveToke(string refreshToken);

	}
}
