using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Web.Models
{
    public class ObjetivosList
    {
        public Guid ObjetivosId { get; set; }

        public float Peso { get; set; }

        public float Pescoco { get; set; }

        public float Cintura { get; set; }

        public float Quadris { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "[dd/MM/YYYY]")]
        //[Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DataObjetivo { get; set; }

        public string UserId { get; set; }
    }
}
