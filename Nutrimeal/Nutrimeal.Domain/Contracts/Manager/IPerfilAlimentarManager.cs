using Nutrimeal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IPerfilAlimentarManager
    {
        Guid Create(Models.PerfilAlimentar perfilAlimentar);
        Task CreateAsync(PerfilAlimentar perfilAlimentar);
        void Edit(Models.PerfilAlimentar perfilAlimentar);
        void EditCaloriasPerfilAlimentar(Models.PerfilAlimentar perfilAlimentar);
        Guid Delete(Models.PerfilAlimentar perfilAlimentar);
        Models.PerfilAlimentar Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Models.PerfilAlimentar> GetAll();


    }
}
