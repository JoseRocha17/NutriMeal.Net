using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class AdminListViewModel : BaseViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public Task<ApplicationUser> User { get; set; }
    }
}
