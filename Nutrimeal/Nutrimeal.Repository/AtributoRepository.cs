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
    public class AtributoRepository : IAtributoRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public AtributoRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public AtributoRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as Atributo;
            if (entityToSave != null)
            {
                var remAtributo = _repositoryContext.Atributo.Single(s => s.AtributoId == entityToSave.AtributoId);

                _repositoryContext.Atributo.Remove(remAtributo);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as Atributo;
            var entityInDb = _repositoryContext.Atributo.Single(o => o.AtributoId == entityToUpdate.AtributoId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Nome = entityToUpdate.Nome;




                _repositoryContext.Atributo.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.Atributo.Single(s => s.AtributoId == id);
            return (T)obj;
        }

        public List<Atributo> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.Atributo.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as Atributo;

            if (entityToSave != null) _repositoryContext.Atributo.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
