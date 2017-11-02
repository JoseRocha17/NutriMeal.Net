using Nutrimeal.Models.PerfilAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class PerfilAlimentarListViewModel : BaseViewModel
    {
        public string UserEmail { get; set; }

        public string UserId { get; set; }

        public List<PerfilAlimentarInList> Items { get; set; } = new List<PerfilAlimentarInList>();
    }
}
