﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Entities
{
    public class EntitiesBase
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy{ get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}