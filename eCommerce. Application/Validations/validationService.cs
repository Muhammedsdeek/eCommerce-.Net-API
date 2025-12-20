using eCommerce._Application.DTOs;
using FluentValidation;

namespace eCommerce._Application.Validations
{
	public class validationService : IvalidateService

	{

		public validationService()
		{
			
		}
		public async Task<ServiceResponse> ValidateAsyncs<T>(T model, IValidator<T> Validator)
		{
			
			var _validation= await Validator.ValidateAsync(model);

			if(!_validation
				.IsValid)
			{

				var Errors =
					  _validation.Errors.Select(d => d.ErrorMessage).ToList();	

				string ErrorToString=string.Join(":",Errors);

				return new ServiceResponse(message: ErrorToString);
			}

			return new ServiceResponse(Success: true);

		}
	}

}
