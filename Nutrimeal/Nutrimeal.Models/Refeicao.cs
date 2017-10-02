using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class Refeicao
    {
        public Guid RefeicaoId { get; set; }
        public string Nome { get; set; }
        public Guid PerfilAlimentarId { get; set; }
    }
}
