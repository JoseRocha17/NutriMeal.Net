using Nutrimeal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Repository
{
    public interface IPerfilAlimentarRepository : IRepositoryBase
    {
        void Edit<T>(T entity);
        void EditCaloriasPerfilAlimentar<T>(T entity);
        T Get<T>(Guid id);
        List<PerfilAlimentar> GetAll(int page = 0, int howMany = 20);
    }
}
