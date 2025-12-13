using System.Security.Claims;

namespace eCommerce.Domain.Intefaces.Authentication
{
	public interface ITokenManegment
	{

		string GetRefreshToke();

		Task<List<Claim>> GetUserCliamsFromToke(string Email);

		Task<bool> ValidateRefreshToke(string Token);

		Task<string> GetUserIdByrefreshToke(string RefreshToken);

		Task<int> AddRefreshToke(string UserId,string RefreshToken);

		Task<int>UpdateRefreshToke(string UserId, string RefreshToken);

		string GenerateToken(List<Claim> Claims);


	}
}
