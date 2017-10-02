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
    public class QuantidadeAlimentarManager : IQuantidadeAlimentarManager
    {

        private readonly IQuantidadeAlimentarRepository _quantidadeAlimentarRepository;

        public QuantidadeAlimentarManager(IQuantidadeAlimentarRepository quantidadeAlimentarRepository)
        {
            _quantidadeAlimentarRepository = quantidadeAlimentarRepository;
        }

        public Guid Create(QuantidadeAlimentar quantidadeAlimentar)
        {
            quantidadeAlimentar.QuantidadeAlimentarId = Guid.NewGuid();
            _quantidadeAlimentarRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.QuantidadeAlimentar>(quantidadeAlimentar));
            return quantidadeAlimentar.QuantidadeAlimentarId;
        }

        public Task CreateAsync(QuantidadeAlimentar quantidadeAlimentar)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(QuantidadeAlimentar quantidadeAlimentar)
        {
            if (quantidadeAlimentar != null) _quantidadeAlimentarRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.QuantidadeAlimentar>(quantidadeAlimentar));
            return quantidadeAlimentar.QuantidadeAlimentarId;
        }

        public void Edit(QuantidadeAlimentar quantidadeAlimentar)
        {
            if (Get(quantidadeAlimentar.QuantidadeAlimentarId) != null)
                _quantidadeAlimentarRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.QuantidadeAlimentar>(quantidadeAlimentar));
        }

        public QuantidadeAlimentar Get(Guid id)
        {
            if (id != null)
            {
                var quantidadeAlimentar = _quantidadeAlimentarRepository.Get<Domain.Entities.QuantidadeAlimentar>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.QuantidadeAlimentar>(quantidadeAlimentar);
            }
            else return null;
        }

        public List<QuantidadeAlimentar> GetAll()
        {
            var quantidadesAlimentaresList = _quantidadeAlimentarRepository.GetAll<Domain.Entities.QuantidadeAlimentar>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Models.QuantidadeAlimentar>>(quantidadesAlimentaresList);
        }
    }
}
