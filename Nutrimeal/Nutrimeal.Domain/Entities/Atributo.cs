using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Entities
{
    public class Atributo : EntitiesBase
    {
        public Guid AtributoId { get; set; }
        public string Nome { get; set; }
    }
}
