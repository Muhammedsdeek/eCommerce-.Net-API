using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace eCommerce.Domain.Entities
{
    public class Product
    {

		[Key]
		public Guid Id { get; set; }


		public string? Name { get; set; }


		public string? Description { get; set; }


		public string?	 ImageUrl	 { get; set; }

		public int Price { get; set; }

		public int? Quantity { get; set; }


		public Category? Category { get; set; }

		[ForeignKey("Category")]
		public Guid? CategoryId { get; set; }




	}
}
