using Nutrimeal.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class QuantidadeAlimentar
    {
        public Guid QuantidadeAlimentarId { get; set; }
        public float Quantidade { get; set; }
        public TipoQuantidade TipoMedida { get; set; }
        public Guid AlimentoId { get; set; }
        public Guid RefeicaoId { get; set; }
    }
}
