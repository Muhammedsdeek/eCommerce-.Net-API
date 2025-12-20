using System.Security.Claims;

namespace eCommerce.Domain.Intefaces.Authentication
{
	public interface ITokenManegment
	{

		string GetRefreshToke();

		List<Claim> GetUserCliamsFromToke(string token);

		Task<bool> ValidateRefreshToke(string Token);

		Task<string> GetUserIdByrefreshToke(string RefreshToken);

		Task<int> AddRefreshToke(string UserId,string RefreshToken);

		Task<int>UpdateRefreshToke(string UserId, string RefreshToken);

	Task<	string> GenerateToken(List<Claim> Claims);


	}
}
