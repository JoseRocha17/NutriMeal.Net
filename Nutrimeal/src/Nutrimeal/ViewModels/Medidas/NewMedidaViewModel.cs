using Nutrimeal.Web.Models.Medidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewMedidaViewModel : BaseViewModel
    {
        public MedidasInList MedidaInput { get; set; } = new MedidasInList();
    }
}
