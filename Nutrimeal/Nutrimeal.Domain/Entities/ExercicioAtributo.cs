using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Entities
{
    public class ExercicioAtributo : EntitiesBase
    {
        public Guid ExercicioAtributoId { get; set; }
        public Guid MetaExercicioId { get; set; }
        public Guid AtributoId { get; set; }
        public float Valor { get; set; }
    }
}
