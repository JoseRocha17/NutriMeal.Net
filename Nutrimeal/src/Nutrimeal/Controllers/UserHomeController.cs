using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Nutrimeal.Models;
using Microsoft.AspNetCore.Identity;
using Nutrimeal.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    [Authorize(Roles = "User")]
    public class UserHomeController : Controller
    {
        // GET: /<controller>/

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserHomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserId(User);
            var vm = new UserHomeViewModel
            {
                UserId = _userManager.GetUserId(User)
            };
            return View(vm);
        }
    }
}
