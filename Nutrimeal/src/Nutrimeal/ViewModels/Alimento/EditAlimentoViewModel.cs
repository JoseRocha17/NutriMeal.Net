using Nutrimeal.Models.Alimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditAlimentoViewModel : BaseViewModel
    {
        public AlimentoInList AlimentoToUpdate { get; set; } = new AlimentoInList();
    }
}
