using eCommerce._Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.Validations
{
	public	 interface IvalidateService
	{

		Task<ServiceResponse> ValidateAsyncs<T>(T model, IValidator<T> Validator);
	}

}
