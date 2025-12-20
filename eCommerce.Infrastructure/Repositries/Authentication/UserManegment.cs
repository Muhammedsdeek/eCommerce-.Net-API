using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Intefaces.Authentication;
using eCommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Security.Claims;

namespace eCommerce.Infrastructure.Repositries.Authentication
{
	public class UserManegment(IRoleManegment roleManegment,UserManager<AppUser> userManager,AppDbContext context) : IUserManegment
	{
		public async Task<bool> CreateUser(AppUser User)
		{
			var _user = await GetUserByEmail(User!.Email);

			if (_user != null)
					return false;

			return (await userManager.CreateAsync(User!, User.PasswordHash!)).Succeeded;

			
		}

		public async Task<IEnumerable<AppUser?>> GetAllUsers()
		{
				return   userManager.Users.ToImmutableList();  //Todo Check IF Return Must Be List!!!!
		}

		public async Task<AppUser?> GetUserByEmail(string Email)
		{
			return await userManager.FindByEmailAsync(Email);
		}

		public async Task<AppUser> GetuserById(string Id)
		{
			return await userManager.FindByIdAsync(Id);

		}

		public async Task<List<Claim>> GetUsersClaims(string Email)
		{
			

			var _User= await GetUserByEmail(Email);
			string? RoleName = await roleManegment.GetUserRole(_User!.Email!);

			var  Cliams = new List<Claim> {

				 new Claim("FullName",_User!.FullName!),
				 new Claim(ClaimTypes.NameIdentifier,_User!.Id),
				 new Claim(ClaimTypes.Email,_User!.Email!),
				 new Claim(ClaimTypes.Role,RoleName!)

			};

			return Cliams;
		}

		public async Task<bool> LoginUser(AppUser User)
		{
			
			var _user=
				await GetUserByEmail(User.Email!);

			if(_user is null)
				return false;



			var RoleNAme= await roleManegment.GetUserRole(_user!.Email!);

			if(string.IsNullOrEmpty(RoleNAme))
				return false;

			///updated to use password hash

			var Result = await userManager.CheckPasswordAsync(_user, User.PasswordHash);
			return Result;  /* await userManager.CheckPasswordAsync(_user, _user.PasswordHash)*/;
			

		}

		//Todo  Add Users TAbles By Add Migrations
		public async Task<int> RemoveUserByEmail(string Email)
		{
			var User =
				await context.Users.FirstOrDefaultAsync(d => d.Email == Email);

			context.Users.Remove(User);
			return await context.SaveChangesAsync();


		}
	}
}
