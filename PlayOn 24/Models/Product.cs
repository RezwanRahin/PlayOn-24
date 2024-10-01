using System.ComponentModel.DataAnnotations;

namespace PlayOn_24.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please provide a Name")]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		public string? PhotoPath { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
