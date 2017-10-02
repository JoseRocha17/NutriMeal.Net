using Nutrimeal.Models.Refeicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditRefeicaoViewModel : BaseViewModel
    {
        public RefeicaoInList RefeicaoToUpdate { get; set; } = new RefeicaoInList();
    }
}
