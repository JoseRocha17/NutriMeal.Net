using Nutrimeal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class ObjetivosListViewModel : BaseViewModel
    {

        public List<ObjetivosCreate> Items { get; set; } = new List<ObjetivosCreate>();
    }
}
