using eCommerce._Application.DTOs.Identity;
using FluentValidation;

namespace eCommerce._Application.Validations.Authentication
{
	public class LoginUserValidate:AbstractValidator<LoginUsr>
	{




		public LoginUserValidate()
		{
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd")
				.EmailAddress().WithMessage("Invalid Email format");

			RuleFor(d => d.Passwod).NotEmpty().WithMessage("Password  is requied");
		}

	}
}
