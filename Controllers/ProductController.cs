using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using table.context;
using table.Models;

namespace table.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;

		//private readonly ILogger<HomeController> _logger;

		public ProductController(ApplicationDbContext context)
		{
			_context = context;
			//_logger = logger;
		}

		public IActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(products);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
