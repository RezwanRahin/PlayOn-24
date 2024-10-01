using System.ComponentModel.DataAnnotations;

namespace PlayOn_24.ViewModels.ProductViewModels
{
	public class ProductDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		public string? PhotoPath { get; set; }
	}
}
