using Nutrimeal.Models.Alimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewAlimentoViewModel : BaseViewModel
    {
        public AlimentoInList AlimentoInput { get; set; } = new AlimentoInList();
    }
}
