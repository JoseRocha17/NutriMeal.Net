using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Entities
{
    public class PerfilFisico : EntitiesBase
    {
        public Guid PerfilFisicoId { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string UserId { get; set; }
    }
}
