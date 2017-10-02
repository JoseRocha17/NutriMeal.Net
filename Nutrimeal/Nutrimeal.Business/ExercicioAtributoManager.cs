using Nutrimeal.Domain.Contracts.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrimeal.Models;
using Nutrimeal.Domain.Contracts.Repository;

namespace Nutrimeal.Business
{
    public class ExercicioAtributoManager : IExercicioAtributoManager
    {
        private readonly IExercicioAtributoRepository _exercicioAtributoRepository;

        public ExercicioAtributoManager(IExercicioAtributoRepository exercicioAtributoRepository)
        {
            _exercicioAtributoRepository = exercicioAtributoRepository;
        }

        public Guid Create(ExercicioAtributo exercicioAtributo)
        {
            exercicioAtributo.ExercicioAtributoId = Guid.NewGuid();
            _exercicioAtributoRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.ExercicioAtributo>(exercicioAtributo));
            return exercicioAtributo.ExercicioAtributoId;
        }

        public Task CreateAsync(ExercicioAtributo exercicioAtributo)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(ExercicioAtributo exercicioAtributo)
        {
            if (exercicioAtributo != null) _exercicioAtributoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.ExercicioAtributo>(exercicioAtributo));
            return exercicioAtributo.ExercicioAtributoId;
        }

        public void DeleteMetaExercicioWithAtributo(Guid metaExercicioId, List<ExercicioAtributo> exercicioAtributo)
        {
            if (metaExercicioId != null)
            {
                foreach (var item in exercicioAtributo)
                {
                    if (item.MetaExercicioId == metaExercicioId)
                    {
                        _exercicioAtributoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.ExercicioAtributo>(item));
                    }
                }
            }
        }

        public void Edit(ExercicioAtributo exercicioAtributo)
        {
            if (Get(exercicioAtributo.ExercicioAtributoId) != null)
                _exercicioAtributoRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.ExercicioAtributo>(exercicioAtributo));
        }
    

        public ExercicioAtributo Get(Guid id)
        {
            if (id != null)
            {
                var exercicioAtributo = _exercicioAtributoRepository.Get<Domain.Entities.ExercicioAtributo>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.ExercicioAtributo>(exercicioAtributo);
            }
            else return null;
        }

        public List<ExercicioAtributo> GetAll()
        {
            var exercicioAtributoList = _exercicioAtributoRepository.GetAll<Domain.Entities.ExercicioAtributo>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Models.ExercicioAtributo>>(exercicioAtributoList);
        }
    }
}
