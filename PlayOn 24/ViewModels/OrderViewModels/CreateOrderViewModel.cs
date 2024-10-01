using System.ComponentModel.DataAnnotations;
using PlayOn_24.ViewModels.ProductViewModels;

namespace PlayOn_24.ViewModels.OrderViewModels
{
	public class CreateOrderViewModel
	{
		[Required]
		public ProductDetailsViewModel Product { get; set; }

		[Required]
		[Range(1, 100, ErrorMessage = "Value must be greater than or equal to 1.")]
		public int Quantity { get; set; } = 1;

		[Required]
		public int ProductId { get; set; }
		
		[Required]
		public int CustomerId { get; set; }
	}
}
