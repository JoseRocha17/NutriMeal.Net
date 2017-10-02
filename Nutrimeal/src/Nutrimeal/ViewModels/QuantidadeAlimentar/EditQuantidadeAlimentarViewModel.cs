using Nutrimeal.Models.QuantidadeAlimentar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditQuantidadeAlimentarViewModel : BaseViewModel
    {
        public QuantidadeAlimentarInList QuantidadeAlimentarToUpdate { get; set; } = new QuantidadeAlimentarInList();
    }
}
