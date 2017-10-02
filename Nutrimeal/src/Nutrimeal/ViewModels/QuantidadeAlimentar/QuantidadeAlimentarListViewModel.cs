using Nutrimeal.Domain.Entities;
using Nutrimeal.Models.QuantidadeAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class QuantidadeAlimentarListViewModel : BaseViewModel
    {
        public string RefeicaoNome { get; set; }
        public string AlimentoNome { get; set; }
        public List<QuantidadeAlimentarInList> Items { get; set; } = new List<QuantidadeAlimentarInList>();
    }
}
