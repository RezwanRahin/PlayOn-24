using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using PlayOn_24.Repository;

namespace PlayOn_24.Controllers
{
	public class ReportController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IWebHostEnvironment _hostEnvironment;

		public ReportController(IOrderRepository orderRepository, IWebHostEnvironment hostEnvironment)
		{
			_orderRepository = orderRepository;
			_hostEnvironment = hostEnvironment;
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
		}

		[HttpGet]
		public async Task<IActionResult> Print(int orderId)
		{
			var order = await _orderRepository.GetOrderById(orderId);

			if (order == null)
			{
				Response.StatusCode = 404;
				ViewBag.ErrorMessage = $"Order with ID = {orderId} cannot be found";
				return View("NotFound");
			}

			string data = $"Id: {order.Id}  Item: {order.Product.Name}  Price: {order.Product.Price}  Quantity: {order.Quantity}  Total: {order.Product.Price * order.Quantity}  Customer: {order.Customer.Name}";

			string mimtype = "";
			int extension = 1;
			var path = $"{_hostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";

			Dictionary<string, string> parameters = new Dictionary<string, string>();
			// parameters.Add("ReportParameter1", "Welcome to Coding World!");
			parameters.Add("ReportParameter1", data);

			LocalReport localReport = new LocalReport(path);
			var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);

			return File(result.MainStream, "application/pdf");
		}
	}
}
