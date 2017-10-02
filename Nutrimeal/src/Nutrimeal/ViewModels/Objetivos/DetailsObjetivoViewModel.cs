using Nutrimeal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsObjetivoViewModel : BaseViewModel
    {
        public ObjetivosList Item { get; set; } = new ObjetivosList();
    }
}
