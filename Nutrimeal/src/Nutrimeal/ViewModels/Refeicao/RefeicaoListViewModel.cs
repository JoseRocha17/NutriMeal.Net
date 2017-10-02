using Nutrimeal.Models.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class RefeicaoListViewModel : BaseViewModel
    {
        public Guid PerfilAlimentarId { get; set; }
        public string PerfilAlimentarNome { get; set; }
        public DateTime PerfilAlimentarData { get; set; }
        public List<RefeicaoInList> Items { get; set; } = new List<RefeicaoInList>();
    }
}
