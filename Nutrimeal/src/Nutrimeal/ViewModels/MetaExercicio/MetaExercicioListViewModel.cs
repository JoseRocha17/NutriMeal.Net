using Nutrimeal.Models.MetaExercicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class MetaExercicioListViewModel : BaseViewModel
    {
        public Guid PerfilFisicoId { get; set; }
        public string ExercicioNome { get; set; }
        public string PerfilFisicoNome { get; set; }
        public List<MetaExercicioInList> Items { get; set; } = new List<MetaExercicioInList>();
    }
}
