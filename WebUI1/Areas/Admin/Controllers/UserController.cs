﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI1.Areas.Admin.ViewModels;
using WebUI1.Models;

namespace WebUI1.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {

            try
            {
                var users = _userManager.Users.ToList();
                return View(users);

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> AddRole(string id)
        {

            try
            {
                if (id == null) return NotFound();

                User user = await _userManager.FindByIdAsync(id);

                if (user == null) return NotFound();

                var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
                var roles = _roleManager.Roles.Select(x => x.Name).ToList();

                UserRoleVM userRoleVM = new()
                {
                    User = user,
                    Roles = roles.Except(userRoles)
                };

                return View(userRoleVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string id, string role)
        {

            try
            {
                if (id == null) return NotFound();

                User user = await _userManager.FindByIdAsync(id);

                if (user == null) return NotFound();

                var userAddRole = await _userManager.AddToRoleAsync(user, role);

                if (!userAddRole.Succeeded)
                {
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(string userid)
        {


            try
            {
                if (userid == null) return NotFound();
                User user = await _userManager.FindByIdAsync(userid);
                if (user == null) return NotFound();

                return View(user);

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(string userid, string role)
        {

            try
            {
                if (userid == null || role == null) return NotFound();

                User user = await _userManager.FindByIdAsync(userid);
                if (user == null) return NotFound();

                IdentityResult resalt = await _userManager.RemoveFromRoleAsync(user, role);

                if (!resalt.Succeeded)
                {
                    ViewBag.Error = "Something went wrong!";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

    }
}
