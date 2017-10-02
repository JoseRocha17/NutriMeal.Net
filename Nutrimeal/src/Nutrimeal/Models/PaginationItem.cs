using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrimeal.Models
{
    public class PaginationItem
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public bool IsCurrent { get; set; }
    }
}
