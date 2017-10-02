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
    public class MedidasManager : IMedidasManager
    {
        private readonly IMedidasRepository _medidasRepository;

        public MedidasManager(IMedidasRepository medidasRepository)
        {
            _medidasRepository = medidasRepository;
        }

        public Guid Create(Medidas medida)
        {
            medida.MedidaId = Guid.NewGuid();
            _medidasRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Medidas>(medida));
            return medida.MedidaId;
        }

        public Task CreateAsync(Medidas medida)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(Medidas medida)
        {
            if (medida != null) _medidasRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Medidas>(medida));
            return medida.MedidaId;
        }

        public void Edit(Medidas medida)
        {
            if (Get(medida.MedidaId) != null)
                _medidasRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Medidas>(medida));
        }

        public Medidas Get(Guid id)
        {
            if (id != null)
            {
                var medida = _medidasRepository.Get<Domain.Entities.Medidas>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.Medidas>(medida);
            }
            else return null;
        }

        public List<Medidas> GetAll()
        {
            var medidasList = _medidasRepository.GetAll<Domain.Entities.Medidas>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Medidas>>(medidasList);
        }
    }
}
