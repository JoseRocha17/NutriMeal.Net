using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class UserManagementAddRoleViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string NewRole { get; set; }
        public SelectList Roles { get; set; }
        //public List<IdentityRole> Roles { get; set; }
    }
}
