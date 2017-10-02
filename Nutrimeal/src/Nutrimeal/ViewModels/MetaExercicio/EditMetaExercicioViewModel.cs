using Nutrimeal.Models.Exercicio;
using Nutrimeal.Models.MetaExercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditMetaExercicioViewModel : BaseViewModel
    {
        public List<ExercicioInList> Items { get; set; } = new List<ExercicioInList>();
        public MetaExercicioInList MetaExercicioOnList { get; set; } = new MetaExercicioInList();
    }
}
