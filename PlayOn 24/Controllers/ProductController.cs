using Microsoft.AspNetCore.Mvc;
using PlayOn_24.Extensions;
using PlayOn_24.Models;
using PlayOn_24.Repository;
using PlayOn_24.ViewModels.ProductViewModels;

namespace PlayOn_24.Controllers
{
	public class ProductController : Controller
	{
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductRepository productRepository, IWebHostEnvironment hostEnvironment)
		{
            _productRepository = productRepository;
            _hostEnvironment = hostEnvironment;
        }

		public async Task<IActionResult> Index()
		{
			var model = await _productRepository.GetAllProducts();
			return View(model);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var product = new Product
			{
				Name = model.Name,
				Price = model.Price,
				PhotoPath = model.Photo.ProcessUploadedFile(_hostEnvironment),
			};

			await _productRepository.Add(product);

			return RedirectToAction("Details", new { id = product.Id});
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var product = await _productRepository.GetProductById(id);

			if (product == null)
            {
                Response.StatusCode = 404;
                ViewBag.ErrorMessage = $"Product with ID = {id} cannot be found";
                return View("NotFound");
            }

			var model = new ProductDetailsViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				PhotoPath = product.PhotoPath.GetPhoto()
			};

			return View(model);
		}
	}
}
