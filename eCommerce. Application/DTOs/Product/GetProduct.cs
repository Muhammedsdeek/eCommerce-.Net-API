using eCommerce._Application.DTOs.Category;

namespace eCommerce._Application.DTOs.Product
{
	public class GetProduct :ProductBase {


		public Guid Id { get; set; }

		public GetCategory? Category { get; set; }
	}
}
