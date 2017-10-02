using Nutrimeal.Models.MetaExercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DeleteMetaExercicioViewModel : BaseViewModel
    {
        public MetaExercicioInList MetaExercicioOnList { get; set; } = new MetaExercicioInList();
    }
}
