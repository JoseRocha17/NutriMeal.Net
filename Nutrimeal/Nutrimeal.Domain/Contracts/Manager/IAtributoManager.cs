using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IAtributoManager
    {
        Guid Create(Models.Atributo atributo);
        Task CreateAsync(Models.Atributo atributo);
        void Edit(Models.Atributo atributo);
        Guid Delete(Models.Atributo atributo);
        Models.Atributo Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Models.Atributo> GetAll();
    }
}
