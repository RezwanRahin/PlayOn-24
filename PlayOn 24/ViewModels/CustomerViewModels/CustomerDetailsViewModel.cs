using System.ComponentModel.DataAnnotations;

namespace PlayOn_24.ViewModels.CustomerViewModels
{
	public class CustomerDetailsViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
	}
}
