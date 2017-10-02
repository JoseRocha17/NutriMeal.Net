using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Entities
{
    public class Refeicao : EntitiesBase
    {
        public Guid RefeicaoId { get; set; }
        public string Nome { get; set; }
        public Guid PerfilAlimentarId { get; set; }
    }
}
