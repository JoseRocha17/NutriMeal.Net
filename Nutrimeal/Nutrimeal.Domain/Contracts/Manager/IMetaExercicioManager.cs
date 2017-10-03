using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IMetaExercicioManager
    {
        Guid Create(Models.MetaExercicio metaExercicio);
        Task CreateAsync(MetaExercicio metaExercicio);
        void Edit(Models.MetaExercicio metaExercicio);
        Guid Delete(Models.MetaExercicio metaExercicio);
        Models.MetaExercicio Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<MetaExercicio> GetAll();
        void DeletePerfilFisicoWithMetaExercicio(Guid PerfilFisicoId, List<Models.MetaExercicio> metaExercicios, List<Models.ExercicioAtributo> exercicioAtributos);

    }
}
