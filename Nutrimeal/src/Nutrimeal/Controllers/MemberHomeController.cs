using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MemberHomeController : Controller
    {
        // GET: /<controller>/
        //[Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }


        //[Authorize(Roles = "Admin")]
        public IActionResult AccessGranted()
        {
            return View();
        }
    }
}
