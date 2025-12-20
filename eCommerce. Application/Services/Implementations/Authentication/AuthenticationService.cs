using AutoMapper;
using eCommerce._Application.DTOs;
using eCommerce._Application.DTOs.Identity;
using eCommerce._Application.Services.Interfaces.Authentication;
using eCommerce._Application.Services.Interfaces.Logging;
using eCommerce._Application.Validations;
using eCommerce.Domain.Entities.Identity;
using eCommerce.Domain.Intefaces.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Services.Implementations.Authentication
{
	public class AuthenticationService(IUserManegment userManegment,
		IMapper mapper,
		ITokenManegment tokenManegment,
		IRoleManegment roleManegment,
		IAppLOgger<AuthenticationService> logger,
		IValidator<CreateUser> CreateUservalidator,
		IValidator<LoginUsr> LoginUserValidator,IvalidateService Validator ) : IAuthenticationService
	{
		public async Task<ServiceResponse> CareteUser(CreateUser User)
		{

			var Result =
				 await Validator.ValidateAsyncs(User, CreateUservalidator);
			
			if(!Result.Success) return Result;

			var MappedData=
				mapper.Map<AppUser>(User);

			MappedData.UserName = User.Email;
			MappedData.PasswordHash = User.Passwod;

			var SaveREsult =
				await userManegment.CreateUser(MappedData);
			if (!SaveREsult)
				return new ServiceResponse(message: "Email address must be  alredy in user or unkonw error occured");

			var newUser =
				await userManegment.GetUserByEmail(User.Email);

			 var USers=
				await userManegment.GetAllUsers();
			bool AddUsserToRole =
			   await roleManegment.AddUserToRole(newUser, USers!.Count() > 1 ? "User" : "Admin");



			if (!AddUsserToRole)
			{

				//Remove user

				int removeUSer =
					await userManegment.RemoveUserByEmail(newUser.Email);
				if (removeUSer <= 0)
				{
					logger.LogError(new Exception($"User with  email ;{newUser.Email}  faild to be rmove as  a result of role assigning issue"),
						"User could not  be  assignde role");

					return new ServiceResponse(message: "errpr occured in create User");

				}


				


			}

			return new ServiceResponse(message: "account created", Success: true);

			//todo Verify Email 


		}

		public async Task<LoginResponse> LoginUser(LoginUsr User)
		{


			var _validation =
				await Validator.ValidateAsyncs(User, LoginUserValidator);


			if (!_validation.Success)
				return  new LoginResponse(message:_validation.message);


			//
			var USerID =
				(await userManegment.GetUserByEmail(User.Email)).Id;
			///
			var MappedData = mapper.Map<AppUser>(User);
			MappedData.UserName = User.Email; //for testing purpose
			MappedData.PasswordHash = User.Passwod;
			MappedData.Id = USerID;

			bool loginResult =
				await userManegment.LoginUser(MappedData);
			if (!loginResult)
			{
				return new LoginResponse(message: "Invalide Email OR Password");
			}

			var _User=await userManegment.GetUserByEmail(User.Email);
			var Claims = await userManegment.GetUsersClaims(User.Email);

			string  jwtToken=
				await tokenManegment.GenerateToken(Claims);

			string REfreshToken =  tokenManegment.GetRefreshToke();

			var UserTokencheck=  await
				 tokenManegment.ValidateRefreshToke(REfreshToken);
			int SAVTEtOKENrESULT = 0;

			if ( UserTokencheck)
				tokenManegment.UpdateRefreshToke(_User.Id, REfreshToken);
			else
				SAVTEtOKENrESULT = await tokenManegment.AddRefreshToke(MappedData.Id, REfreshToken);



			return SAVTEtOKENrESULT <= 0 ? new LoginResponse(message: "internal merror occured  while  authentication ") :
				new LoginResponse(success: true, Token: jwtToken, RefreshToken: REfreshToken);
				
			







	

		}

		public async Task<LoginResponse> REviveToke(string refreshToken)
		{
			var _ValidToken= await tokenManegment.ValidateRefreshToke(refreshToken);
			if (!_ValidToken)
				return new LoginResponse(message: "Invalide Token");


			var UserID=
				await tokenManegment.GetUserIdByrefreshToke(refreshToken);
			AppUser? user=
				await userManegment.GetuserById(UserID);
			var Claims=
				await userManegment.GetUsersClaims(user.Email);
			var newjwtToke=
				await tokenManegment.GenerateToken(Claims);
			var newREfreshToken =
				 tokenManegment.GetRefreshToke();
			tokenManegment.UpdateRefreshToke(UserID, newREfreshToken);
			return 
				new LoginResponse(success:true, Token: newjwtToke, RefreshToken:newREfreshToken);


			
		}
	}
}
