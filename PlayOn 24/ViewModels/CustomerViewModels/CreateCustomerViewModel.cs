using System.ComponentModel.DataAnnotations;

namespace PlayOn_24.ViewModels.CustomerViewModels
{
	public class CreateCustomerViewModel
	{
		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }
	}
}
