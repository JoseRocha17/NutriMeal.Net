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
    public class MetaExercicioManager : IMetaExercicioManager
    {
        private readonly IMetaExercicioRepository _metaExercicioRepository;

        public MetaExercicioManager(IMetaExercicioRepository metaExercicioRepository)
        {
            _metaExercicioRepository = metaExercicioRepository;
        }

        public Guid Create(MetaExercicio metaExercicio)
        {
            metaExercicio.MetaExercicioId = Guid.NewGuid();
            _metaExercicioRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.MetaExercicio>(metaExercicio));
            return metaExercicio.MetaExercicioId;
        }

        public Task CreateAsync(MetaExercicio metaExercicio)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(MetaExercicio metaExercicio)
        {
            if (metaExercicio != null) _metaExercicioRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.MetaExercicio>(metaExercicio));
            return metaExercicio.MetaExercicioId;
        }



        public void Edit(MetaExercicio metaExercicio)
        {
            if (Get(metaExercicio.MetaExercicioId) != null)
                _metaExercicioRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.MetaExercicio>(metaExercicio));
        }

        public MetaExercicio Get(Guid id)
        {
            if (id != null)
            {
                var metaExercicio = _metaExercicioRepository.Get<Domain.Entities.MetaExercicio>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.MetaExercicio>(metaExercicio);
            }
            else return null;
        }

        public List<MetaExercicio> GetAll()
        {
            var metaExercicioList = _metaExercicioRepository.GetAll<Domain.Entities.MetaExercicio>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Models.MetaExercicio>>(metaExercicioList);
        }
    }
}
