using Microsoft.AspNetCore.Mvc;
using PlayOn_24.Models;
using PlayOn_24.Repository;
using PlayOn_24.ViewModels.CustomerViewModels;

namespace PlayOn_24.Controllers
{
	public class CustomerController : Controller
	{
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
		{
            _customerRepository = customerRepository;
        }

		public async Task<IActionResult> Index()
		{
			var model = await _customerRepository.GetAllCustomers();
			return View(model);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCustomerViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var customer = new Customer
			{
				Name = model.Name,
				Email = model.Email.ToString()
			};

			await _customerRepository.Add(customer);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCustomers()
		{
			var customers = await _customerRepository.GetAllCustomers();
			return Json(customers);
		}
	}
}
