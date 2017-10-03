using Nutrimeal.Models;
using Nutrimeal.Models.PerfilFisico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class PerfilFisicoListViewModel : BaseViewModel
    {
        public string UserEmail { get; set; }

        public List<PerfilFisicoInList> Items { get; set; } = new List<PerfilFisicoInList>();
    }
}
