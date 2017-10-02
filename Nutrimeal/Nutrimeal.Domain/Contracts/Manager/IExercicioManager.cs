using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IExercicioManager
    {
        Guid Create(Models.Exercicio exercicio);
        Task CreateAsync(Exercicio exercicio);
        void Edit(Models.Exercicio exercicio);
        Guid Delete(Models.Exercicio exercicio);
        Models.Exercicio Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Exercicio> GetAll();
    }
}
