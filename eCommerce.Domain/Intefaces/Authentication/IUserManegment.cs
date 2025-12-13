using eCommerce.Domain.Entities.Identity;
using System.Security.Claims;

namespace eCommerce.Domain.Intefaces.Authentication
{
	public interface IUserManegment
	{


		Task<bool> CreateUser(AppUser User);	


		Task<AppUser?> GetUserByEmail(string Email);

		Task<bool> LoginUser(AppUser User);


		Task<AppUser> GetuserById(string Id);

		Task<IEnumerable<AppUser?>> GetAllUsers();

		Task<int> RemoveUserByEmail(string Email);


		Task<List<Claim>> GetUsersClaims(string Email);


			

	}
}
