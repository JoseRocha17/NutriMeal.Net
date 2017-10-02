using Nutrimeal.Models.Alimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DeleteAlimentoViewModel : BaseViewModel
    {
        public AlimentoInList AlimentoToDelete { get; set; } = new AlimentoInList();
    }
}
