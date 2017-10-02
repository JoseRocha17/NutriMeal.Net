using Nutrimeal.Models.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewRefeicaoViewModel : BaseViewModel
    {
        public Guid PerfilAlimentarId { get; set; }
        public RefeicaoInList RefeicaoInput { get; set; } = new RefeicaoInList();
    }
}
