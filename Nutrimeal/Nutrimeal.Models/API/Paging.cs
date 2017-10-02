using System.Collections.Generic;

namespace Nutrimeal.Models.API
{
    public class Paging
    {
        public int CurrentIndex { get; set; } = 0;

        public int HowManyPerPage { get; set; }

        public List<NavigationItem> Parameters { get; set; } = new List<NavigationItem>();

        public int Total { get; set; } = 0;

        public int TotalPages => (Total > 0)
                                    ? Total / HowManyPerPage + (Total % HowManyPerPage != 0 ? 1 : 0)
            : 0;
    }
}