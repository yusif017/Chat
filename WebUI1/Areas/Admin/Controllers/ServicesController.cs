using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using WebUI1.Data;
using WebUI1.Helper;
using WebUI1.Models;

namespace WebUI1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _env;
        public ServicesController(AppDbContext context, IHttpContextAccessor contextAccessor, IWebHostEnvironment env)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _env = env;
        }

        public IActionResult Index()
        {
            var praduct = _context.Services.ToList();
            return View(praduct);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            try
            {


                await _context.Services.AddAsync(service);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            var praduct = _context.Services.FirstOrDefault(a => a.Id == id);
            if (praduct == null) return NotFound();
            return View(praduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Service service)
        {
            try
            {
                _context.Services.Update(service);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var praduct = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

            _context.Services.Remove(praduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
    }
}



