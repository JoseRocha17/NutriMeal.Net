using Nutrimeal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IRefeicaoManager
    {
        Guid Create(Models.Refeicao refeicao);
        Task CreateAsync(Refeicao refeicao);
        void Edit(Models.Refeicao refeicao);
        Guid Delete(Models.Refeicao refeicao);
        Models.Refeicao Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Models.Refeicao> GetAll();
        void DeletePerfilAlimentarWithRefeicao(Guid PerfilAlimentarId, List<Models.Refeicao> refeicoes, List<Models.QuantidadeAlimentar> quantidadesAlimementares);
    }
}
