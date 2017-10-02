using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IMedidasManager
    {
        Guid Create(Models.Medidas medida);
        Task CreateAsync(Medidas medida);
        void Edit(Models.Medidas medida);
        Guid Delete(Models.Medidas medida);
        Models.Medidas Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Medidas> GetAll();
    }
}
