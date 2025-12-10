using eCommerce._Application.DTOs.Product;

namespace eCommerce._Application.DTOs.Category
{
	public class GetCategory : CategoryBase
	{

		public Guid Id { get; set; }


		public ICollection<GetProduct>	 Products { get; set; }
	}




}

