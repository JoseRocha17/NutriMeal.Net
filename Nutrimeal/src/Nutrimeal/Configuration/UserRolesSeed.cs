using Nutrimeal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Nutrimeal.Configuration
{
    public class UserRolesSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRolesSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            //context.Roles.Add(new IdentityRole { Name="Admin"});
        }

        public async void Seed()
        {
            if ((await _roleManager.FindByNameAsync("Admin")) == null)
            {
               await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if ((await _roleManager.FindByNameAsync("User")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }
            if ((await _roleManager.FindByNameAsync("Nutricionist")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Nutricionist" });
            }
            if ((await _roleManager.FindByNameAsync("PersonalTrainer")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "PersonalTrainer" });
            }

        }

    }
}
