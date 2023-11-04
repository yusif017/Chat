using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebUI1.Data;
using WebUI1.Helper;
using WebUI1.Models;

namespace WebUI1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _env;
        public AboutController(AppDbContext context, IHttpContextAccessor contextAccessor, IWebHostEnvironment env)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _env = env;
        }

        public IActionResult Index()
        {
            var praduct = _context.Abauts.ToList();
            return View(praduct);
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(Abaut abaut)
        //{
        //    try
        //    {


        //        await _context.Abauts.AddAsync(abaut);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //        return View();
        //    }

        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            var praduct = _context.Abauts.FirstOrDefault(a => a.Id == id);
            if (praduct == null) return NotFound();
            return View(praduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Abaut abaut)
        {
            try
            {
                _context.Abauts.Update(abaut);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var praduct = await _context.Abauts.FirstOrDefaultAsync(x => x.Id == id);

        //    _context.Abauts.Remove(praduct);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");


        //}
    }
}



