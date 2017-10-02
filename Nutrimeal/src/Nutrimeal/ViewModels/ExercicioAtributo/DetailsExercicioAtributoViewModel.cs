using Nutrimeal.Models.ExercicioAtributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsExercicioAtributoViewModel : BaseViewModel
    {
        public string ExercicioNome { get; set; }
        public string AtributoNome { get; set; }
        public ExercicioAtributoInList Item { get; set; } = new ExercicioAtributoInList();
    }
}
