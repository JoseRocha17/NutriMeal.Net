using Nutrimeal.Web.Models.Medidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsMedidaViewModel : BaseViewModel
    {
        public MedidasInList Item { get; set; } = new MedidasInList();
    }
}
