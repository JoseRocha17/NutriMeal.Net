using Nutrimeal.Models.Exercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsExercicioViewModel : BaseViewModel
    {
        public ExercicioInList Item { get; set; } = new ExercicioInList();
    }
}
