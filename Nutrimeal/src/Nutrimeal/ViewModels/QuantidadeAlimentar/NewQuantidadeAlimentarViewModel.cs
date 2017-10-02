using Nutrimeal.Models;
using Nutrimeal.Models.Alimento;
using Nutrimeal.Models.QuantidadeAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewQuantidadeAlimentarViewModel : BaseViewModel
    {
        public List<AlimentoInList> Items { get; set; } = new List<AlimentoInList>();
        public Guid RefeicaoId { get; set; }
        public QuantidadeAlimentarInList QuantidadeAlimentarInput { get; set; } = new QuantidadeAlimentarInList();
    }
}
