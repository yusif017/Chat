

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUICha.Data;

namespace WebUICha.Controllers
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
            
            return View();
        }

        //public IActionResult Abaut()
        //{
        //    var context = _context.Messages.ToList();
        //    return View(context);
        //}

    }
}