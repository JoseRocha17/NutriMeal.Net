using Nutrimeal.Models;
using Nutrimeal.Models.ExercicioAtributo;
using Nutrimeal.Models.MetaExercicio;
using Nutrimeal.Models.PerfilFisico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.ViewModels
{
    public class DetailsPerfilFisicoViewModel : BaseViewModel
    {
        public Guid MetaExercicioId{ get; set; }
        public string MetaExercicioNome { get; set; }
        public string  AtributoNome { get; set; }
        public PerfilFisicoInList Item { get; set; } = new PerfilFisicoInList();
        public List<ExercicioAtributoInList> ExercicioAtributos { get; set; } = new List<ExercicioAtributoInList>();
        public List<MetaExercicioInList> Items { get; set; } = new List<MetaExercicioInList>();
    }
}
