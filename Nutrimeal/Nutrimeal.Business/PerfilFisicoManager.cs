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
    public class PerfilFisicoManager : IPerfilFisicoManager
    {
        private readonly IPerfilFisicoRepository _PerfilFisicoRepository;

        public PerfilFisicoManager(IPerfilFisicoRepository perfilFisicoRepository)
        {
            _PerfilFisicoRepository = perfilFisicoRepository;
        }

        public Guid Create(PerfilFisico perfilFisico)
        {
            perfilFisico.PerfilFisicoId = Guid.NewGuid();
            _PerfilFisicoRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.PerfilFisico>(perfilFisico));
            return perfilFisico.PerfilFisicoId;
        }

        public Task CreateAsync(PerfilFisico perfilFisico)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(PerfilFisico perfilFisico)
        {
            if (perfilFisico != null) _PerfilFisicoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.PerfilFisico>(perfilFisico));
            return perfilFisico.PerfilFisicoId;
        }

        public void Edit(PerfilFisico perfilFisico)
        {
            if (Get(perfilFisico.PerfilFisicoId) != null)
                _PerfilFisicoRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.PerfilFisico>(perfilFisico));
        }

        public PerfilFisico Get(Guid id)
        {
            if (id != null)
            {
                var perfilFisico = _PerfilFisicoRepository.Get<Domain.Entities.PerfilFisico>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.PerfilFisico>(perfilFisico);
            }
            else return null;
        }

        public List<PerfilFisico> GetAll()
        {
            var perfilFisicoList = _PerfilFisicoRepository.GetAll<Domain.Entities.PerfilFisico>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Models.PerfilFisico>>(perfilFisicoList);
        }
    }
}
