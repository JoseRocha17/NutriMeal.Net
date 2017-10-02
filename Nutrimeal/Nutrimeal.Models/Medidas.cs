using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class Medidas
    {
        public Guid MedidaId { get; set; }

        public float Altura { get; set; }

        public float Peso { get; set; }

        public float Pescoco { get; set; }

        public float Cintura { get; set; }

        public float Quadris { get; set; }

        public DateTime DataMedicao { get; set; }

        public string UserId { get; set; }
    }
}
