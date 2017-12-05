using Nutrimeal.Domain.Contracts.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrimeal.Domain.Entities;
using Nutrimeal.Models;
using Nutrimeal.Domain.Contracts.Repository;

namespace Nutrimeal.Business
{
    public class PerfilAlimentarManager : IPerfilAlimentarManager
    {
        private readonly IPerfilAlimentarRepository _perfilAlimentarRepository;

        public PerfilAlimentarManager(IPerfilAlimentarRepository perfilAlimentarRepository)
        {
            _perfilAlimentarRepository = perfilAlimentarRepository;
        }
        public Guid Create(Models.PerfilAlimentar perfilAlimentar)
        {
            perfilAlimentar.PerfilAlimentarId = Guid.NewGuid();
            _perfilAlimentarRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.PerfilAlimentar>(perfilAlimentar));
            return perfilAlimentar.PerfilAlimentarId;
        }

        public Task CreateAsync(Domain.Entities.PerfilAlimentar perfilAlimentar)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(Models.PerfilAlimentar perfilAlimentar)
        {
            if (perfilAlimentar != null) _perfilAlimentarRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.PerfilAlimentar>(perfilAlimentar));
            return perfilAlimentar.PerfilAlimentarId;
        }

        public void Edit(Models.PerfilAlimentar perfilAlimentar)
        {
            if (Get(perfilAlimentar.PerfilAlimentarId) != null)
                _perfilAlimentarRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.PerfilAlimentar>(perfilAlimentar));
        }

        public void EditCaloriasPerfilAlimentar(Models.PerfilAlimentar perfilAlimentar)
        {
            if (Get(perfilAlimentar.PerfilAlimentarId) != null)
                _perfilAlimentarRepository.EditCaloriasPerfilAlimentar(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.PerfilAlimentar>(perfilAlimentar));
        }

        public Models.PerfilAlimentar Get(Guid id)
        {
            if (id != null)
            {
                var perfilAlimentar = _perfilAlimentarRepository.Get<Domain.Entities.PerfilAlimentar>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.PerfilAlimentar>(perfilAlimentar);
            }
            else return null;
        }

        public List<Models.PerfilAlimentar> GetAll()
        {
            var perfilAlimentarList = _perfilAlimentarRepository.GetAll<Domain.Entities.PerfilAlimentar>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Models.PerfilAlimentar>>(perfilAlimentarList);
        }
    }
}
