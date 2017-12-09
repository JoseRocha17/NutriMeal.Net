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
    public class AlimentoManager : IAlimentoManager
    {
        private readonly IAlimentoRepository _alimentoRepository;

        public AlimentoManager(IAlimentoRepository alimentoRepository)
        {
            _alimentoRepository = alimentoRepository;
        }

        public Guid Create(Alimento alimento)
        {
            alimento.AlimentoId = Guid.NewGuid();
            _alimentoRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Alimento>(alimento));
            return alimento.AlimentoId;
        }

        public Task CreateAsync(Alimento alimento)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(Alimento alimento)
        {
            if (alimento != null) _alimentoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Alimento>(alimento));
            return alimento.AlimentoId;
        }

        public void Edit(Alimento alimento)
        {
            if (Get(alimento.AlimentoId) != null)
                _alimentoRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Alimento>(alimento));
        }

        public void EditCaloriasAlimento(Alimento alimento)
        {
            if (Get(alimento.AlimentoId) != null)
                _alimentoRepository.EditCaloriasAlimento(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Alimento>(alimento));
        }

        public Alimento Get(Guid id)
        {
            if (id != null)
            {
                var alimento = _alimentoRepository.Get<Domain.Entities.Alimento>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.Alimento>(alimento);
            }
            else return null;
        }

        public List<Alimento> GetAll()
        {
            var alimentosList = _alimentoRepository.GetAll<Domain.Entities.Alimento>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Alimento>>(alimentosList);
        }
    }
}
