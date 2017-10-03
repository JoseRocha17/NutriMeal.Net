using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IQuantidadeAlimentarManager
    {
        Guid Create(Models.QuantidadeAlimentar quantidadeAlimentar);
        Task CreateAsync(QuantidadeAlimentar quantidadeAlimentar);
        void Edit(Models.QuantidadeAlimentar quantidadeAlimentar);
        Guid Delete(Models.QuantidadeAlimentar quantidadeAlimentar);
        Models.QuantidadeAlimentar Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<QuantidadeAlimentar> GetAll();
        void DeleteRefeicaoWithAlimentos(Guid refeicaoId, List<QuantidadeAlimentar> quantidadesAlimentares);
    }
}
