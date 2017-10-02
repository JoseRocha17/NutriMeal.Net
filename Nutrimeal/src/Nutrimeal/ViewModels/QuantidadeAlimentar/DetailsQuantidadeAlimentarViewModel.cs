using Nutrimeal.Models.QuantidadeAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsQuantidadeAlimentarViewModel : BaseViewModel
    {
        public string Refeicao { get; set; }
        public QuantidadeAlimentarInList Item { get; set; } = new QuantidadeAlimentarInList();
    }
}
