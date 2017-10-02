using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IExercicioAtributoManager
    {
        Guid Create(Models.ExercicioAtributo exercicioAtributo);
        Task CreateAsync(ExercicioAtributo exercicioAtributo);
        void Edit(Models.ExercicioAtributo exercicioAtributo);
        Guid Delete(Models.ExercicioAtributo exercicioAtributo);
        Models.ExercicioAtributo Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<ExercicioAtributo> GetAll();
        void DeleteMetaExercicioWithAtributo(Guid metaExercicioId, List<ExercicioAtributo> exercicioAtributo);
    }
}
