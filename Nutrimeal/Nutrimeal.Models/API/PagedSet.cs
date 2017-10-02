using System.Collections.Generic;

namespace Nutrimeal.Models.API
{
    public class PagedSet<T> : BaseResult
    {
        public bool HasMore { set; get; }
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
    }
}