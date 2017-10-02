using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Models.ExercicioAtributo
{
    public class ExercicioAtributoInList
    {
        public Guid ExercicioAtributoId { get; set; }
        public Guid MetaExercicioId { get; set; }
        public Guid AtributoId { get; set; }
        public string AtributoNome { get; set; }
        public float Valor { get; set; }
    }
}
