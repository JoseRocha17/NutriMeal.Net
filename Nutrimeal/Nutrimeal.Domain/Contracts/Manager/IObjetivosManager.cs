using Nutrimeal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IObjetivosManager
    {
        Guid Create(Models.Objetivos objetivos);
        Task CreateAsync(Objetivos objetivos);
        void Edit(Models.Objetivos objetivos);
        Guid Delete(Models.Objetivos objetivos);
        Models.Objetivos Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Objetivos> GetAll();
    }
}
