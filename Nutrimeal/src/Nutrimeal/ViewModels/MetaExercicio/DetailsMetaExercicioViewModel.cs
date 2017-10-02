using Nutrimeal.Models.MetaExercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsMetaExercicioViewModel : BaseViewModel
    {
        public string Exercicio { get; set; }
        public string PerfilFisicoNome { get; set; }
        public MetaExercicioInList Item { get; set; } = new MetaExercicioInList();
    }
}
