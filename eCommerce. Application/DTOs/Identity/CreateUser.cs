using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce._Application.DTOs.Identity
{
	public class CreateUser:BaseModel
	{

		public required string  FullName { get; set; }

		public required string ConfirmePasswod { get; set; }	



	}
}
