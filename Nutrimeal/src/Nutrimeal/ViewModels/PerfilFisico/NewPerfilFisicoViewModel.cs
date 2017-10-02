using Nutrimeal.Models.PerfilFisico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewPerfilFisicoViewModel : BaseViewModel
    {
        public string UserId { get; set; }
        public PerfilFisicoInList PerfilFisicoInput { get; set; } = new PerfilFisicoInList();
    }
}
