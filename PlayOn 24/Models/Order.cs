using System.ComponentModel.DataAnnotations;

namespace PlayOn_24.Models
{
	public class Order
	{
		public int Id { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		[Range(1, 100, ErrorMessage = "Quantity must be greater than or equal to 1.")]
		public int Quantity { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
		
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
	}
}
