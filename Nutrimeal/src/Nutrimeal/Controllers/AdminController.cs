using System;
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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
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


    }
}
