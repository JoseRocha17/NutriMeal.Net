using Nutrimeal.Web.Models.Medidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditMedidaViewModel : BaseViewModel
    {
        public MedidasInList MedidaInList { get; set; } = new MedidasInList();
    }
}
