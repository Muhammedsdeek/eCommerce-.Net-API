using System.ComponentModel.DataAnnotations;

namespace eCommerce._Application.DTOs.Category
{
	public class UpdateCategory:CategoryBase
	{
		[Required]
		public Guid Id { get; set; }

		
	}


}

