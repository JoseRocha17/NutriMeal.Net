using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Web.Models.Medidas
{
    public class MedidasInList
    {
        public Guid MedidaId { get; set; }

        public float Altura { get; set; }

        public float Peso { get; set; }

        public float Pescoco { get; set; }

        public float Cintura { get; set; }

        public float Quadris { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "[dd/MM/YYYY]")]
        //[Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DataMedicao { get; set; }

        public string UserId { get; set; }
    }
}
