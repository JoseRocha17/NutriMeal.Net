using Nutrimeal.Models.PerfilAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsPerfilAlimentarViewModel : BaseViewModel
    {
        public PerfilAlimentarInList Item { get; set; } = new PerfilAlimentarInList();
    }
}
