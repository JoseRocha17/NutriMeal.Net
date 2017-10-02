using System.Collections.Generic;

namespace Nutrimeal.Models.API
{
    public class ErrorList<T>
    {
        public List<ErrorActionResult<T>> Items { get; set; } = new List<ErrorActionResult<T>>();
    }
}