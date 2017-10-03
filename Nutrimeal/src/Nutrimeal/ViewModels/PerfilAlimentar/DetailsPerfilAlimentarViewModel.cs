using Nutrimeal.Models.PerfilAlimentar;
using Nutrimeal.Models.QuantidadeAlimentar;
using Nutrimeal.Models.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsPerfilAlimentarViewModel : BaseViewModel
    {
        public PerfilAlimentarInList Item { get; set; } = new PerfilAlimentarInList();
        public List<RefeicaoInList> Items { get; set; } = new List<RefeicaoInList>();
        public string RefeicaoNome { get; set; }

        public List<QuantidadeAlimentarInList> QuantidadesAlimentares { get; set; } = new List<QuantidadeAlimentarInList>();
    }
}
