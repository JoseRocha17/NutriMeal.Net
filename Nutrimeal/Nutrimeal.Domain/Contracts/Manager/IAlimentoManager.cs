using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IAlimentoManager
    {
        Guid Create(Models.Alimento alimento);
        Task CreateAsync(Alimento alimento);
        void Edit(Models.Alimento alimento);
        Guid Delete(Models.Alimento alimento);
        Models.Alimento Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Alimento> GetAll();
    }
}
