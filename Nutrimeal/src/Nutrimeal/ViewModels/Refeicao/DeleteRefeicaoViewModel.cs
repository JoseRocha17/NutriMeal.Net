using Nutrimeal.Models.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DeleteRefeicaoViewModel : BaseViewModel
    {
        public RefeicaoInList RefeicaoInList { get; set; } = new RefeicaoInList();
    }
}
