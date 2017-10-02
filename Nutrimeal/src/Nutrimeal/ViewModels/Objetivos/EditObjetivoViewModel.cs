using Nutrimeal.ViewModels;
using Nutrimeal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditObjetivoViewModel : BaseViewModel
    {
        public ObjetivosList ObjetivoInList { get; set; } = new ObjetivosList();
    }
}
