using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Repository
{
    public interface IRepositoryBase
    {
        void Save<T>(T entity);
        void Delete<T>(T entity);
        T Get<T>(string id);
        List<T> GetAll<T>();
        Task SaveAsync<T>(T entity);
    }
}
