using System.ComponentModel.DataAnnotations;

namespace PlayOn_24.ViewModels.ProductViewModels
{
	public class CreateProductViewModel
	{
		[Required(ErrorMessage = "Please provide a Name")]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Required]
		public IFormFile Photo { get; set; }
	}
}
