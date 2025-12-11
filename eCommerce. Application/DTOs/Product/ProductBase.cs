using System.ComponentModel.DataAnnotations;

namespace eCommerce._Application.DTOs.Product
{
	public class ProductBase
	{
		[Required]
		public string? Name { get; set; }

		[Required]
		public string? Description { get; set; }
		[Required]

		public string? ImageUrl { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public int Price { get; set; }
		[Required]
		public int? Quantity { get; set; }
		[Required]
		public Guid? CategoryId { get; set; }

	}
}
