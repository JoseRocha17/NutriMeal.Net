using Nutrimeal.Domain.Contracts.Repository;
using Nutrimeal.Repository.Ef.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrimeal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nutrimeal.Repository.ef
{
    public class ObjetivosRepository : IObjetivosRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public ObjetivosRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ObjetivosRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as Objetivos;
            var entityInDb = _repositoryContext.Objetivos.Single(o => o.ObjetivosId == entityToUpdate.ObjetivosId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Peso = entityToUpdate.Peso;
                entityInDb.Pescoco = entityToUpdate.Pescoco;
                entityInDb.Cintura = entityToUpdate.Cintura;
                entityInDb.Quadris = entityToUpdate.Quadris;
                entityInDb.DataObjetivo = entityToUpdate.DataObjetivo;


                _repositoryContext.Objetivos.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.Objetivos.Single(s => s.ObjetivosId == id);
            return (T)obj;
        }

        public List<Objetivos> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as Objetivos;

            if (entityToSave != null) _repositoryContext.Objetivos.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as Objetivos;
            if (entityToSave != null)
            {
                var remObjetivo = _repositoryContext.Objetivos.Single(s => s.ObjetivosId == entityToSave.ObjetivosId);

                _repositoryContext.Objetivos.Remove(remObjetivo);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.Objetivos.AsNoTracking().ToList() as List<T>;
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
