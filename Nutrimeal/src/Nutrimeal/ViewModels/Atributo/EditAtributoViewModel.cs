using Nutrimeal.Models.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditAtributoViewModel : BaseViewModel
    {
        public AtributoInList AtributoToEdit { get; set; } = new AtributoInList();
    }
}
