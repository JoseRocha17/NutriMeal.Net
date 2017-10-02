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
    public class ExercicioAtributoRepository : IExercicioAtributoRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public ExercicioAtributoRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ExercicioAtributoRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as ExercicioAtributo;
            if (entityToSave != null)
            {
                var remExercicioAtributo = _repositoryContext.ExercicioAtributo.Single(s => s.ExercicioAtributoId == entityToSave.ExercicioAtributoId);

                _repositoryContext.ExercicioAtributo.Remove(remExercicioAtributo);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as ExercicioAtributo;
            var entityInDb = _repositoryContext.ExercicioAtributo.Single(o => o.ExercicioAtributoId == entityToUpdate.ExercicioAtributoId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.MetaExercicioId = entityToUpdate.MetaExercicioId;
                entityInDb.AtributoId = entityToUpdate.AtributoId;
                entityInDb.Valor = entityToUpdate.Valor;



                _repositoryContext.ExercicioAtributo.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.ExercicioAtributo.Single(s => s.ExercicioAtributoId == id);
            return (T)obj;
        }

        public List<ExercicioAtributo> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.ExercicioAtributo.AsNoTracking().ToList() as List<T>;
        }
    

        public void Save<T>(T entity)
        {
        var entityToSave = entity as ExercicioAtributo;

        if (entityToSave != null) _repositoryContext.ExercicioAtributo.Add(entityToSave);

        _repositoryContext.SaveChanges();
    }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
