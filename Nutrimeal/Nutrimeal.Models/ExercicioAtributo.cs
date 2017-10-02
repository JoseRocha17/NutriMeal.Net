using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class ExercicioAtributo
    {
        public Guid ExercicioAtributoId { get; set; }
        public Guid MetaExercicioId { get; set; }
        public Guid AtributoId { get; set; }
        public float Valor { get; set; }
    }
}
