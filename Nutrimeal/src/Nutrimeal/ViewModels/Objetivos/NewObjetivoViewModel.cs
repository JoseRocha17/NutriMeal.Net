using Nutrimeal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewObjetivoViewModel : BaseViewModel
    {
        public ObjetivosCreate ObjetivoInput { get; set; } = new ObjetivosCreate();
    }
}
