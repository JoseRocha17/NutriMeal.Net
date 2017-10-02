using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Entities
{
    public class Exercicio : EntitiesBase
    {
        public Guid ExercicioId { get; set; }
        public string Nome { get; set; }
        public TipoExercicio Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
