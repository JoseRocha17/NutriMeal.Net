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
    public class MetaExercicioRepository : IMetaExercicioRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public MetaExercicioRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public MetaExercicioRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as MetaExercicio;
            if (entityToSave != null)
            {
                var remMetaExercicio = _repositoryContext.MetaExercicio.Single(s => s.MetaExercicioId == entityToSave.MetaExercicioId);

                _repositoryContext.MetaExercicio.Remove(remMetaExercicio);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as MetaExercicio;
            var entityInDb = _repositoryContext.MetaExercicio.Single(o => o.MetaExercicioId == entityToUpdate.MetaExercicioId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Calorias = entityToUpdate.Calorias;
                entityInDb.PerfilFisicoId = entityToUpdate.PerfilFisicoId;
                entityInDb.ExercicioId = entityToUpdate.ExercicioId;



                _repositoryContext.MetaExercicio.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.MetaExercicio.Single(s => s.MetaExercicioId == id);
            return (T)obj;
        }

        public List<MetaExercicio> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.MetaExercicio.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as MetaExercicio;

            if (entityToSave != null) _repositoryContext.MetaExercicio.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
