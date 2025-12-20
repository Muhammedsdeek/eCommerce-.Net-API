using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Intefaces.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositries.Authentication
{
	public class RoleManegment(UserManager<AppUser> userManager) : IRoleManegment
	{
		public async Task<bool> AddUserToRole(AppUser User, string RoleName)
		{

			var Result = await userManager.AddToRoleAsync(User, RoleName);

			return Result.Succeeded ? true : false;

		}

		public async Task<string?> GetUserRole(string Email)
		{
		
			var User= await userManager.FindByEmailAsync(Email);
			var Roles =
				await userManager.GetRolesAsync(User);
			var RoleName= Roles.FirstOrDefault();

			return (await userManager.GetRolesAsync(User)).FirstOrDefault();

		


		}


	}
}
