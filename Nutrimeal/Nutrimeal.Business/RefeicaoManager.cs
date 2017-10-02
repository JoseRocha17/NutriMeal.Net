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
    public class RefeicaoManager : IRefeicaoManager
    {

        private readonly IRefeicaoRepository _refeicaoRepository;

        public RefeicaoManager(IRefeicaoRepository refeicaoRepository)
        {
            _refeicaoRepository = refeicaoRepository;
        }

        public Guid Create(Models.Refeicao refeicao)
        {
            refeicao.RefeicaoId = Guid.NewGuid();
            _refeicaoRepository.Save(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Refeicao>(refeicao));
            return refeicao.RefeicaoId;
        }

        public Task CreateAsync(Domain.Entities.Refeicao refeicao)
        {
            throw new NotImplementedException();
        }

        public Guid Delete(Models.Refeicao refeicao)
        {
            if (refeicao != null) _refeicaoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Refeicao>(refeicao));
            return refeicao.RefeicaoId;
        }

        public void Edit(Models.Refeicao refeicao)
        {
            if (Get(refeicao.RefeicaoId) != null)
                _refeicaoRepository.Edit(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Refeicao>(refeicao));
        }

        public Models.Refeicao Get(Guid id)
        {
            if (id != null)
            {
                var refeicao = _refeicaoRepository.Get<Domain.Entities.Refeicao>(id);

                return Code.EfAutoMapperConfig.Mapped.Map<Models.Refeicao>(refeicao);
            }
            else return null;
        }

        public List<Models.Refeicao> GetAll()
        {
            var refeicaoList = _refeicaoRepository.GetAll<Domain.Entities.Refeicao>();

            return Code.EfAutoMapperConfig.Mapped.Map<List<Models.Refeicao>>(refeicaoList);
        }
    }
}
