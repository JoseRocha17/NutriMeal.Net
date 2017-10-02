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
    public class AtributoManager : IAtributoManager
    {
        private readonly IAtributoRepository _atributoRepository;

        public AtributoManager(IAtributoRepository atributoRepository)
        {
            _atributoRepository = atributoRepository;
        }

        public Guid Create(Atributo atributo)
        {
            atributo.AtributoId = Guid.NewGuid();
            _atributoRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Atributo>(atributo));
            return atributo.AtributoId;
        }

        public Task CreateAsync(Atributo atributo)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(Atributo atributo)
        {
            if (atributo != null) _atributoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Atributo>(atributo));
            return atributo.AtributoId;
        }

        public void Edit(Atributo atributo)
        {
            if (Get(atributo.AtributoId) != null)
                _atributoRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Atributo>(atributo));
        }

        public Atributo Get(Guid id)
        {
            if (id != null)
            {
                var atributo = _atributoRepository.Get<Domain.Entities.Atributo>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.Atributo>(atributo);
            }
            else return null;
        }

        public List<Atributo> GetAll()
        {
            var atributoList = _atributoRepository.GetAll<Domain.Entities.Atributo>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Models.Atributo>>(atributoList);
        }
    }
}
