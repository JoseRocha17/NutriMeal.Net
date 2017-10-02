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
    public class QuantidadeAlimentarRepository : IQuantidadeAlimentarRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public QuantidadeAlimentarRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public QuantidadeAlimentarRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as QuantidadeAlimentar;
            if (entityToSave != null)
            {
                var remQuantidadeAlimentar = _repositoryContext.QuantidadeAlimentar.Single(s => s.QuantidadeAlimentarId == entityToSave.QuantidadeAlimentarId);

                _repositoryContext.QuantidadeAlimentar.Remove(remQuantidadeAlimentar);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as QuantidadeAlimentar;
            var entityInDb = _repositoryContext.QuantidadeAlimentar.Single(o => o.QuantidadeAlimentarId == entityToUpdate.QuantidadeAlimentarId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Quantidade = entityToUpdate.Quantidade;
                entityInDb.TipoMedida = entityToUpdate.TipoMedida;




                _repositoryContext.QuantidadeAlimentar.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.QuantidadeAlimentar.Single(s => s.QuantidadeAlimentarId == id);
            return (T)obj;
        }

        public List<QuantidadeAlimentar> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.QuantidadeAlimentar.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as QuantidadeAlimentar;

            if (entityToSave != null) _repositoryContext.QuantidadeAlimentar.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
