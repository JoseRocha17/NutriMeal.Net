using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class BaseViewModel
    {
        public string PageName { get; set; }

        public string ErrorMessage { get; set; }

        public List<PaginationItem> PaginationItems { get; set; } = new List<PaginationItem>();
    }
}
