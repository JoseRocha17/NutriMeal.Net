using Nutrimeal.Models.Alimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class AlimentoListViewModel : BaseViewModel
    {
        public List<AlimentoInList> Items { get; set; } = new List<AlimentoInList>();
    }
}
