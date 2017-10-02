﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Models.MetaExercicio
{
    public class MetaExercicioInList
    {
        
        public Guid MetaExercicioId { get; set; }
        public float Calorias { get; set; }

        public string  ExercicioNome { get; set; }
        public Guid PerfilFisicoId { get; set; }
        public Guid ExercicioId { get; set; }
    }
}
