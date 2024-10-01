using Microsoft.AspNetCore.Mvc;
using PlayOn_24.Extensions;
using PlayOn_24.Models;
using PlayOn_24.Repository;
using PlayOn_24.ViewModels.CustomerViewModels;
using PlayOn_24.ViewModels.OrderViewModels;
using PlayOn_24.ViewModels.ProductViewModels;

namespace PlayOn_24.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRepository;
		private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OrderController(IOrderRepository orderRepository,
								 IProductRepository productRepository, 
								 ICustomerRepository customerRepository,
								 IWebHostEnvironment hostEnvironment)
		{
			_orderRepository = orderRepository;
			_productRepository = productRepository;
			_customerRepository = customerRepository;
            _hostEnvironment = hostEnvironment;
        }

		public async Task<IActionResult> Index(int customerId)
		{
			var model = new ListOrderViewModel();

			if (customerId == 0)
			{
				model.Orders = await _orderRepository.GetAllOrders();
			}
			else
			{
				model.Orders = await _orderRepository.GetAllOrdersByCustomer(customerId);
			}

			if (model.Orders == null)
			{
				Response.StatusCode = 404;
				ViewBag.ErrorMessage = $"Order with Customer ID = {customerId} cannot be found";
				return View("NotFound");
			}

			// var model = await _orderRepository.GetAllOrders();
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Create(int productId)
		{
			var product = await _productRepository.GetProductById(productId);

			if (product == null)
			{
				Response.StatusCode = 404;
				ViewBag.ErrorMessage = $"Product with ID = {productId} cannot be found";
				return View("NotFound");
			}

			var model = new CreateOrderViewModel
			{
				Product = new ProductDetailsViewModel
				{
					Id = product.Id,
					Name = product.Name,
					Price = product.Price,
					PhotoPath = product.PhotoPath.GetPhoto()
				},
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateOrderViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var customer = await _customerRepository.GetCustomerById(model.CustomerId);
			var product = await _productRepository.GetProductById(model.ProductId);

			if (product == null || customer == null)
			{
				Response.StatusCode = 404;
				ViewBag.ErrorMessage = $"Product and or Customer cannot be found";
				return View("NotFound");
			}

			var order = new Order
			{
				Date = DateTime.Today,
				Quantity = model.Quantity,
				Product = product,
				Customer = customer
			};

			await _orderRepository.Add(order);

			return RedirectToAction("Details", new { id = order.Id });
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var order = await _orderRepository.GetOrderById(id);

			if (order == null)
			{
				Response.StatusCode = 404;
				ViewBag.ErrorMessage = $"Order with ID = {id} cannot be found";
				return View("NotFound");
			}

			var model = new OrderDetailsViewModel
			{
				Id = id,
				Date = order.Date,
				Quantity = order.Quantity,
				NetCost = order.Product.Price * order.Quantity,
				Product = new ProductDetailsViewModel
				{
					Id = order.Product.Id,
					Name = order.Product.Name,
					Price = order.Product.Price,
					PhotoPath = order.Product.PhotoPath.GetPhoto()
				},
				Customer = new CustomerDetailsViewModel
				{
					Id = order.Customer.Id,
					Name = order.Customer.Name,
					Email = order.Customer.Email
				}
			};

			return View(model);
		}

		// [HttpGet]
		// public async Task<IActionResult> GenerateInvoice(int id)
		// {
		// 	// Fetch invoice data from your database
		// 	var order = await _orderRepository.GetOrderById(id);

		// 	if (order == null)
		// 	{
		// 		Response.StatusCode = 404;
		// 		ViewBag.ErrorMessage = $"Order with ID = {id} cannot be found";
		// 		return View("NotFound");
		// 	}

		// 	// Create a LocalReport object
		// 	var localReport = new LocalReport();
		// 	localReport.ReportPath = Path.Combine(_hostEnvironment.WebRootPath, "Reports", "InvoiceReport.rdlc");

		// 	// Add data sources
		// 	localReport.DataSources.Add(new ReportDataSource("InvoiceDataSet", new List<Invoice> { invoice }));
		// 	localReport.DataSources.Add(new ReportDataSource("InvoiceItemsDataSet", invoice.Items));

		// 	// Render the report to a byte array
		// 	var reportBytes = localReport.Render("PDF");

		// 	// Return the PDF as a file result
		// 	return File(reportBytes, "application/pdf", $"Invoice_{invoice.InvoiceNumber}.pdf");
		// }

	}
}
