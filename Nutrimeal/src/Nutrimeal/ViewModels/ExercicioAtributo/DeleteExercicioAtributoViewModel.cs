using Nutrimeal.Models.ExercicioAtributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DeleteExercicioAtributoViewModel : BaseViewModel
    {
        public ExercicioAtributoInList ExercicioAtributoToDelete { get; set; } = new ExercicioAtributoInList();
    }
}
