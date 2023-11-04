using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI1.Data;
using WebUI1.Models;
using WebUI1.ViewModels;

namespace WebUI1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var productSliders = _context.ProductSliders.ToList();
            var products = _context.Products.ToList();
            var services = _context.Services.ToList();
            var abauts = _context.Abauts.FirstOrDefault();


            HomeVM homeVM = new()
            {
                ProductSlider = productSliders,
                Product = products,
                Service = services,
                Abaut = abauts
            };
            return View(homeVM);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}