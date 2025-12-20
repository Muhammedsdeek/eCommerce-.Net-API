using eCommerce._Application.DTOs.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Validations.Authentication
{
	public class CreateUserValidate:AbstractValidator<CreateUser>
	{

		public CreateUserValidate()
		{
			RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is requierd");

			RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd")
				.EmailAddress().WithMessage("Invalid Email format");

			RuleFor(x => x.Passwod)
			   .NotEmpty().WithMessage("Password is required")
			   .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
			   .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
			   .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
			   .Matches(@"[0-9]").WithMessage("Password must contain at least one number")
			   .Matches(@"[^\w]").WithMessage("Password must contain at least one special character");

			RuleFor(x => x.ConfirmePasswod).Equal(x => x.Passwod).WithMessage("Passwords do not match");
		}
	}
}
