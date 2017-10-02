using Nutrimeal.Models.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsAtributoViewModel : BaseViewModel
    {
        public AtributoInList Item { get; set; } = new AtributoInList();
    }
}
