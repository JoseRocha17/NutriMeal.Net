using Nutrimeal.Models.PerfilAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewPerfilAlimentarViewModel : BaseViewModel
    {
        public string UserId { get; set; }
        public PerfilAlimentarInList PerfilAlimentarInput { get; set; } = new PerfilAlimentarInList();
    }
}
