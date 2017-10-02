using Nutrimeal.Models.ExercicioAtributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class EditExercicioAtributoViewModel : BaseViewModel
    {
        public ExercicioAtributoInList ExercicioAtributoToEdit { get; set; } = new ExercicioAtributoInList();
    }
}
