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
        private readonly IQuantidadeAlimentarRepository _quantidadeAlimentarRepository;

        public RefeicaoManager(IRefeicaoRepository refeicaoRepository, IQuantidadeAlimentarRepository quantidadeAlimentarRepository)
        {
            _refeicaoRepository = refeicaoRepository;
            _quantidadeAlimentarRepository = quantidadeAlimentarRepository;
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

        public void DeletePerfilAlimentarWithRefeicao(Guid PerfilAlimentarId, List<Models.Refeicao> refeicoes, List<Models.QuantidadeAlimentar> quantidadesAlimementares)
        {
            if(PerfilAlimentarId != null)
            {
                foreach(var item in refeicoes)
                {
                    if(item.PerfilAlimentarId == PerfilAlimentarId)
                    {
                        foreach(var itemQ in quantidadesAlimementares)
                        {
                            if (itemQ.RefeicaoId != null && itemQ.RefeicaoId == item.RefeicaoId)
                            {
                                //_refeicaoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Refeicao>(item));
                                _quantidadeAlimentarRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.QuantidadeAlimentar>(itemQ));
                            }
                        }
                        _refeicaoRepository.Delete(Code.EfAutoMapperConfig.Mapped.Map<Domain.Entities.Refeicao>(item));

                    }
                }
            }
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
