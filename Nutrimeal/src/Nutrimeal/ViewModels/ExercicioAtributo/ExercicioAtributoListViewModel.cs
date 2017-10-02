using Nutrimeal.Models.ExercicioAtributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class ExercicioAtributoListViewModel : BaseViewModel
    {
        public Guid MetaExercicioId { get; set; }
        public string ExercicioNome { get; set; }
        public List<ExercicioAtributoInList> Items { get; set; } = new List<ExercicioAtributoInList>();
    }
}
