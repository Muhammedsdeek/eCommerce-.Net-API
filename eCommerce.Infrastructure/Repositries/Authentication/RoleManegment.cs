using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Intefaces.Authentication;
using eCommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositries.Authentication
{
	internal class RoleManegment(UserManager<AppUser> userManager) : IRoleManegment
	{
		public async Task<bool> AddUserToRole(AppUser User, string RoleName)
		{

			var Result = await userManager.AddToRoleAsync(User, RoleName);

			return Result.Succeeded ? true : false;

		}
			
	



		public async Task<string?> GetUserRole(string Email)
		{
		
			var User= await userManager.FindByEmailAsync(Email);

			return (await userManager.GetRolesAsync(User!)).FirstOrDefault();

		}


	}



	public class UserManegment(IRoleManegment roleManegment,UserManager<AppUser> userManager,AppDbContext context) : IUserManegment
	{
		public async Task<bool> CreateUser(AppUser User)
		{
			AppUser? _user = await GetUserByEmail(User.Email);

			if (_user != null)
			{
				var result = await userManager.CreateAsync(User!,User.PasswordHash!);
				if (result.Succeeded)
					return true;

				return false;

			}

			return false;

		}

		public async Task<IEnumerable<AppUser?>> GetAllUsers()
		{
		 return   userManager.Users.ToImmutableList();
		}

		public async Task<AppUser?> GetUserByEmail(string Email)
		{
			return await userManager.FindByEmailAsync(Email);	
		}

		public async Task<AppUser> GetuserById(string Id)
		{
			return await userManager.FindByIdAsync(Id);

		}

		public Task<List<Claim>> GetUsersClaims(string Email)
		{
			throw new NotImplementedException();
		}

		public Task<bool> LoginUser(AppUser User)
		{
			throw new NotImplementedException();
		}

		public Task<int> RemoveUserByEmail(string Email)
		{
			throw new NotImplementedException();
		}
	}
}
