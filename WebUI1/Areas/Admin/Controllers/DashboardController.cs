using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebUI1.Data;

namespace WebUI1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var con = _context.Contacts.ToList();
            return View(con);
        }
        public async Task<IActionResult> Deteil(int id)
        {
            if (id == null) return NotFound();
            var contact = _context.Contacts.SingleOrDefault(x => x.Id == id);
            if (contact == null) return NotFound();
            return View(contact);
        }
    }
}
