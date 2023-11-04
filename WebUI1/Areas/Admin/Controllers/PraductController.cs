using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebUI1.Data;
using WebUI1.Helper;
using WebUI1.Models;

namespace WebUI1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class PraductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _env;
        public PraductController(AppDbContext context, IHttpContextAccessor contextAccessor, IWebHostEnvironment env)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _env = env;
        }

        public IActionResult Index()
        {
            var praduct = _context.Products.ToList();
            return View(praduct);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile Photo)
        {
            try
            {

                product.PhotoUrl = await FileUploud.SeveFileAsync(Photo, _env.WebRootPath);
                await _context.Products.AddAsync(product);
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
            var praduct = _context.Products.FirstOrDefault(a => a.Id == id);
            if (praduct == null) return NotFound();
            return View(praduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile Photo)
        {
            try
            {

                if (Photo != null)
                {
                    product.PhotoUrl = await FileUploud.SeveFileAsync(Photo, _env.WebRootPath);

                }
                _context.Products.Update(product);
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
            var praduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            _context.Products.Remove(praduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
    }
}





