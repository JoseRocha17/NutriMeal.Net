using Nutrimeal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DeleteObjetivoViewModel : BaseViewModel
    {
        public ObjetivosList ObjetivoInList { get; set; } = new ObjetivosList();
    }
}
