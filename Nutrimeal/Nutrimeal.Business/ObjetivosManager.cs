using Nutrimeal.Domain.Contracts.Manager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nutrimeal.Domain.Entities;
using Nutrimeal.Domain.Contracts.Repository;
using Nutrimeal.Repository.Code;
using Nutrimeal.Repository.ef;
using Nutrimeal.Business.Code;

namespace Nutrimeal.Business
{
    public class ObjetivosManager : IObjetivosManager
    {
        private readonly IObjetivosRepository _objetivosRepository;

        public ObjetivosManager(IObjetivosRepository objetivosRepository)
        {
            _objetivosRepository = objetivosRepository;
        }

        public ObjetivosManager()
        {
            _objetivosRepository = new ObjetivosRepository();
        }
        public Guid Create(Models.Objetivos objetivos)
        {
            objetivos.ObjetivosId = Guid.NewGuid();
            _objetivosRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Objetivos>(objetivos));
            return objetivos.ObjetivosId;
        }

        public Task CreateAsync(Objetivos objetivos)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(Models.Objetivos objetivos)
        {
            if (objetivos != null) _objetivosRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Objetivos>(objetivos));
            return objetivos.ObjetivosId;
        }

        public void Edit(Models.Objetivos objetivos)
        {
            if (Get(objetivos.ObjetivosId) != null)
                _objetivosRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Objetivos>(objetivos));
        }

        public Models.Objetivos Get(Guid id)
        {
            if (id != null)
            {
                var objetivo = _objetivosRepository.Get<Domain.Entities.Objetivos>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.Objetivos>(objetivo);
            }
            else return null;
        }

        public List<Objetivos> GetAll()
        {
            var objetivosList = _objetivosRepository.GetAll<Domain.Entities.Objetivos>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Objetivos>>(objetivosList);
        }
    }
}
