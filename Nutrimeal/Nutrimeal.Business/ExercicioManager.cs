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
    public class ExercicioManager : IExercicioManager
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExercicioManager(IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }

        public Guid Create(Exercicio exercicio)
        {
            exercicio.ExercicioId = Guid.NewGuid();
            _exercicioRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Exercicio>(exercicio));
            return exercicio.ExercicioId;
        }

        public Task CreateAsync(Exercicio exercicio)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(Exercicio exercicio)
        {
            if (exercicio != null) _exercicioRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Exercicio>(exercicio));
            return exercicio.ExercicioId;
        }

        public void Edit(Exercicio exercicio)
        {
            if (Get(exercicio.ExercicioId) != null)
                _exercicioRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Exercicio>(exercicio));
        }

        public Exercicio Get(Guid id)
        {
            if (id != null)
            {
                var exercicio = _exercicioRepository.Get<Domain.Entities.Exercicio>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.Exercicio>(exercicio);
            }
            else return null;
        }

        public List<Exercicio> GetAll()
        {
            var exerciciosList = _exercicioRepository.GetAll<Domain.Entities.Exercicio>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Exercicio>>(exerciciosList);
        }
    }
}
