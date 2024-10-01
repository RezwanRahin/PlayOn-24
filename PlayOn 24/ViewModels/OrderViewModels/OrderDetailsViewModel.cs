using System.ComponentModel.DataAnnotations;
using PlayOn_24.ViewModels.CustomerViewModels;
using PlayOn_24.ViewModels.ProductViewModels;

namespace PlayOn_24.ViewModels.OrderViewModels
{
	public class OrderDetailsViewModel
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }
		
		public int Quantity { get; set; }

		[DataType(DataType.Currency)]
		public decimal NetCost { get; set; }

		public ProductDetailsViewModel Product { get; set; }
		public CustomerDetailsViewModel Customer { get; set; }
	}
}
