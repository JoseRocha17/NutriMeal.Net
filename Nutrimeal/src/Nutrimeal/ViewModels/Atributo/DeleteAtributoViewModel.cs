using Nutrimeal.Models.Atributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DeleteAtributoViewModel : BaseViewModel
    {
        public AtributoInList AtributoToDelete { get; set; } = new AtributoInList();
    }
}
