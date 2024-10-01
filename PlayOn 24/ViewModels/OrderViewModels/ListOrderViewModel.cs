using PlayOn_24.Models;

namespace PlayOn_24.ViewModels.OrderViewModels
{
	public class ListOrderViewModel
	{
		public IEnumerable<Order>? Orders { get; set; }
		public int? CustomerId { get; set; } = 0;
	}
}
