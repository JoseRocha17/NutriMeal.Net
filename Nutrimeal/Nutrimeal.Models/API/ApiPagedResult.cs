using System.Collections.Generic;

namespace Nutrimeal.Models.API
{
    public class ApiPagedResult<T>:BaseResult
    {
   
        public IEnumerable<T> Items { get; set; }
  
        public List<Page> Pages { get; set; }
        public Paging Paging { get; set; } = new Paging { CurrentIndex = 0, HowManyPerPage = 30 };

        public void BuildPages()
        {
            Pages = new List<Page>();

            for (var i = 0; i < Paging.TotalPages; i++)
            {
                Pages.Add(new Page { Index = i, IsCurrent = i == Paging.CurrentIndex });
            }
        }
    }
}