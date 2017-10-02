using Nutrimeal.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrimeal.Domain.Entities;
using Nutrimeal.Repository.Ef.Context;
using Microsoft.EntityFrameworkCore;

namespace Nutrimeal.Repository
{
    public class PerfilAlimentarRepository : IPerfilAlimentarRepository
    {

        private readonly RepositoryContext _repositoryContext;

        public PerfilAlimentarRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public PerfilAlimentarRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as PerfilAlimentar;
            if (entityToSave != null)
            {
                var remPerfilAlimentar = _repositoryContext.PerfilAlimentar.Single(s => s.PerfilAlimentarId == entityToSave.PerfilAlimentarId);

                _repositoryContext.PerfilAlimentar.Remove(remPerfilAlimentar);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as PerfilAlimentar;
            var entityInDb = _repositoryContext.PerfilAlimentar.Single(o => o.PerfilAlimentarId == entityToUpdate.PerfilAlimentarId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Nome = entityToUpdate.Nome;
                entityInDb.Data = entityToUpdate.Data;




                _repositoryContext.PerfilAlimentar.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.PerfilAlimentar.Single(s => s.PerfilAlimentarId == id);
            return (T)obj;
        }

        public List<PerfilAlimentar> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.PerfilAlimentar.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as PerfilAlimentar;

            if (entityToSave != null) _repositoryContext.PerfilAlimentar.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
