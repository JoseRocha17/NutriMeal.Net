﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Data;
using Microsoft.AspNetCore.Identity;
using Nutrimeal.Models;
using Nutrimeal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult UserList()
        {
            var vm = new AdminListViewModel
            { 
                Users = _dbContext.Users.OrderBy(u => u.Email).ToList()
                
            };
            return View(vm);
        }


        [HttpGet]
        public IActionResult UserDetails(string id)
        {
            var vm = new AdminListViewModel
            {
                Users = _dbContext.Users.OrderBy(u => u.Email).Where(x => x.Id == id).ToList()

            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = await GetUserById(id);

            var vm = new UserManagementAddRoleViewModel
            {
                Roles = GetAllRoles(),
                Email = user.Email,
                UserId = id
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel rvm)
        {
            var user = await GetUserById(rvm.UserId);
            if (ModelState.IsValid)
            {

                var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserDetails/" + rvm.UserId);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }
            rvm.Roles = GetAllRoles();
            rvm.Email = user.Email;
            return View(rvm);
        }

        //Add PhoneNumber

        [HttpGet]
        public async Task<IActionResult> AddPhoneNumber(string id)
        {
            var user = await GetUserById(id);

            var vm = new UserManagementAddPhoneNumberViewModel
            {
                UserId = id
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> AddPhoneNumber(UserManagementAddPhoneNumberViewModel rvm)
        {
            var user = await GetUserById(rvm.UserId);
            if (ModelState.IsValid)
            {

                var result = await _userManager.SetPhoneNumberAsync(user, rvm.PhoneNumber);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserDetails/" + rvm.UserId);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }
            //rvm.Roles = GetAllRoles();
            //rvm.Email = user.Email;
            return View(rvm);
        }



        private async Task<ApplicationUser> GetUserById(string id) => await _userManager.FindByIdAsync(id);

        private SelectList GetAllRoles() => new SelectList(_roleManager.Roles.OrderBy(r => r.Name));

    }

}
