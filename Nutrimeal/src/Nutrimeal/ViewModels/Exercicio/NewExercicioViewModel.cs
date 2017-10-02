using Nutrimeal.Models.Exercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewExercicioViewModel : BaseViewModel
    {
        public ExercicioInList ExercicioInput { get; set; } = new ExercicioInList();
    }
}
