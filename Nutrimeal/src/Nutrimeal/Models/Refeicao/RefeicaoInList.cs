using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Models.Refeicao
{
    public class RefeicaoInList
    {
        public Guid RefeicaoId { get; set; }
        public string Nome { get; set; }
        public Guid PerfilAlimentarId { get; set; }
    }
}
