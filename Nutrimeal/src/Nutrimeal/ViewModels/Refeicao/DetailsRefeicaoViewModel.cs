using Nutrimeal.Models.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsRefeicaoViewModel : BaseViewModel
    {
        public string PerfilAlimentarNome { get; set; }
        public DateTime PerfilAlimentarData { get; set; }
        public RefeicaoInList Item { get; set; } = new RefeicaoInList();
    }
}
