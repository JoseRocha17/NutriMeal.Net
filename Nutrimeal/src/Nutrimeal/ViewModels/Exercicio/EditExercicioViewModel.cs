using Nutrimeal.Models.Exercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditExercicioViewModel : BaseViewModel
    {
        public ExercicioInList ExercicioOnList { get; set; } = new ExercicioInList();
    }
}
