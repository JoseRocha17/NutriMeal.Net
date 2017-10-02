using Nutrimeal.Models.Atributo;
using Nutrimeal.Models.Exercicio;
using Nutrimeal.Models.ExercicioAtributo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class NewExercicioAtributoViewModel : BaseViewModel
    {
        public Guid MetaExercicioId { get; set; }
        public List<AtributoInList> Items { get; set; } = new List<AtributoInList>();
        public ExercicioAtributoInList ExercicioAtributoInput { get; set; } = new ExercicioAtributoInList();
    }
}
