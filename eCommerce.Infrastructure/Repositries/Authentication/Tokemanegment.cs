using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Intefaces.Authentication;
using eCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eCommerce.Infrastructure.Repositries.Authentication
{
	public class Tokemanegment(AppDbContext context,IConfiguration config) : ITokenManegment
	{
		public async Task<int> AddRefreshToke(string UserId, string RefreshToken)
		{
			context.RefreshTokens.Add(new RefreshToken
			{

				UserId = UserId,
				Token = RefreshToken
			});

			return  await context.SaveChangesAsync();
		}

		public async Task<string> GenerateToken(List<Claim> Claims)
		{
			//desgine TOken here
			var Key =
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));

			var cred=
				 new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);

			var Expiration =
				DateTime.UtcNow.AddHours(2);
			var Token =
				 new JwtSecurityToken(

					 issuer: config["JWT:Issuer"],

					 audience: config["JWt:Audience"],
					 claims: Claims,
					 expires: Expiration,
					 signingCredentials: cred

				 );

			///Generate Token
			///

		return new JwtSecurityTokenHandler().WriteToken( Token );

		}

		public string GetRefreshToke()
		{

			const int ByteSize = 64;

			 byte[] bytes = new byte[ByteSize];
			using (RandomNumberGenerator randomNumber = RandomNumberGenerator.Create()) { 
			
			
				randomNumber.GetBytes(bytes);

			}


			//return Convert.ToBase64String(bytes);
			string token= Convert.ToBase64String(bytes);
			return WebUtility.UrlEncode(token);

		}

		public  List<Claim> GetUserCliamsFromToke(string token)
		{
			 var tokenhandeler= new JwtSecurityTokenHandler();
			var JwtToken = tokenhandeler.ReadJwtToken(token);

			if (JwtToken!=null)
			{
				return   JwtToken.Claims.ToList();

			}
			return [];

		}

		public async Task<string> GetUserIdByrefreshToke(string RefreshToken)
		{

			return (await context.RefreshTokens.FirstOrDefaultAsync(d => d.Token == RefreshToken))!.UserId;

		}

		public async Task<int> UpdateRefreshToke(string UserId, string RefreshToken)
		{
			

			var GetToken=await context.RefreshTokens.FirstOrDefaultAsync(d=>d.UserId == UserId);


			if (GetToken == null)
				return -1;
			GetToken.Token = RefreshToken;	
			 context.RefreshTokens.Update(GetToken);
			return await context.SaveChangesAsync();
		}

		public async Task<bool> ValidateRefreshToke(string Token)
		{
			
			var validToken=
				await context.RefreshTokens.FirstOrDefaultAsync(d=>d.Token == Token);

			if (validToken != null)
				return true;

			return false;

		}

		
	}
}
