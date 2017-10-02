using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class MetaExercicio
    {
        public Guid MetaExercicioId { get; set; }
        public float Calorias { get; set; }
        public Guid PerfilFisicoId { get; set; }
        public Guid ExercicioId { get; set; }
    }
}
