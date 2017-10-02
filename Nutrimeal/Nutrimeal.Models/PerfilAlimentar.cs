using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class PerfilAlimentar
    {
        public Guid PerfilAlimentarId { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string UserId { get; set; }
    }
}
