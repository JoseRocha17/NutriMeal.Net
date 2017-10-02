using Nutrimeal.Models.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewAtributoViewModel : BaseViewModel
    {
        public AtributoInList AtributoInput { get; set; } = new AtributoInList();
    }
}
