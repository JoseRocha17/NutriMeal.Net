using Nutrimeal.Web.Models.Medidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class MedidasListViewModel : BaseViewModel
    {
        public List<MedidasInList> Items { get; set; } = new List<MedidasInList>();
    }
}
