using Nutrimeal.Models.Alimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsAlimentoViewModel : BaseViewModel
    {
        public AlimentoInList Item { get; set; } = new AlimentoInList();
        public AlimentoInList AlimentoToUpdate { get; set; } = new AlimentoInList();
    }
}
