using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class Alimento
    {
        public Guid AlimentoId { get; set; }
        public string Nome { get; set; }
        public float Calorias { get; set; }
        public float Gordura { get; set; }
        public float Colestrol { get; set; }
        public float Sodio { get; set; }
        public float Potassio { get; set; }
        public float Carboidrato { get; set; }
        public float Fibra { get; set; }
        public float Acucar { get; set; }
        public float Proteina { get; set; }
        public GrupoAlimento Grupo { get; set; }
    }
}
