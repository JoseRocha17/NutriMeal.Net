using Nutrimeal.Models.QuantidadeAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DeleteQuantidadeAlimentarViewModel : BaseViewModel
    {
        public QuantidadeAlimentarInList QuantidadeAlimentarToDelete { get; set; } = new QuantidadeAlimentarInList();
    }
}
