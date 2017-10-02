using Nutrimeal.Models.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class AtributoListViewModel : BaseViewModel
    {
        public List<AtributoInList> Items { get; set; } = new List<AtributoInList>();
    }
}
