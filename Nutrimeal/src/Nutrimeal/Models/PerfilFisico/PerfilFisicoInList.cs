using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Models.PerfilFisico
{
    public class PerfilFisicoInList
    {
        public Guid PerfilFisicoId { get; set; }
        public string Nome { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "[dd/MM/YYYY]")]
        //[Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
