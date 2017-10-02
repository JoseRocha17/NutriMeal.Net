using Nutrimeal.Models.PerfilAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditPerfilAlimentarViewModel : BaseViewModel
    {
        public PerfilAlimentarInList PerfilInList { get; set; } = new PerfilAlimentarInList();
    }
}
