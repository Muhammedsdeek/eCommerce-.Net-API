namespace eCommerce._Application.DTOs.Product
{
	public class ProductBase
	{
		public string? Name { get; set; }


		public string? Description { get; set; }


		public string? ImageUrl { get; set; }

		public int Price { get; set; }

		public int? Quantity { get; set; }

		public Guid? CategoryId { get; set; }

	}
}
