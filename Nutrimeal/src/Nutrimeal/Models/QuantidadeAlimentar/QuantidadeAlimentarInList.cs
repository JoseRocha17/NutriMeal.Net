using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Models.QuantidadeAlimentar
{
    public class QuantidadeAlimentarInList
    {
        public Guid QuantidadeAlimentarId { get; set; }
        public float Quantidade { get; set; }
        public TipoQuantidade TipoMedida { get; set; }
        public Guid AlimentoId { get; set; }
        public string AlimentoNome { get; set; }
        public float CaloriasDoAlimento { get; set; }
        public Guid RefeicaoId { get; set; }
        public string RefeicaoName { get; set; }
    }
}
