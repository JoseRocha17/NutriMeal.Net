using Nutrimeal.Models.PerfilFisico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditPerfilFisicoViewModel : BaseViewModel
    {
        public PerfilFisicoInList PerfilInList { get; set; } = new PerfilFisicoInList();
    }
}
