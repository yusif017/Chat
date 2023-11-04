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
    public class PraductslidersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _env;
        public PraductslidersController(AppDbContext context, IHttpContextAccessor contextAccessor, IWebHostEnvironment env)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _env = env;
        }

        public IActionResult Index()
        {
            var praduct = _context.ProductSliders.ToList();
            return View(praduct);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductSlider productSlider, IFormFile Photo)
        {
            try
            {

                productSlider.PhotoUrl = await FileUploud.SeveFileAsync(Photo, _env.WebRootPath);
                await _context.ProductSliders.AddAsync(productSlider);
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
            var praduct = _context.ProductSliders.FirstOrDefault(a => a.Id == id);
            if (praduct == null) return NotFound();
            return View(praduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductSlider productSlider, IFormFile Photo)
        {
            try
            {

                if (Photo != null)
                {
                    productSlider.PhotoUrl = await FileUploud.SeveFileAsync(Photo, _env.WebRootPath);

                }
                _context.ProductSliders.Update(productSlider);
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
            var praduct = await _context.ProductSliders.FirstOrDefaultAsync(x => x.Id == id);

            _context.ProductSliders.Remove(praduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
    }
}



