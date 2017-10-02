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
    public class ExercicioRepository : IExercicioRepository
    {

        private readonly RepositoryContext _repositoryContext;

        public ExercicioRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ExercicioRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as Exercicio;
            if (entityToSave != null)
            {
                var remExercicio = _repositoryContext.Exercicio.Single(s => s.ExercicioId == entityToSave.ExercicioId);

                _repositoryContext.Exercicio.Remove(remExercicio);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as Exercicio;
            var entityInDb = _repositoryContext.Exercicio.Single(o => o.ExercicioId == entityToUpdate.ExercicioId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Nome = entityToUpdate.Nome;
                entityInDb.Tipo = entityToUpdate.Tipo;
                entityInDb.Descricao = entityToUpdate.Descricao;


                _repositoryContext.Exercicio.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.Exercicio.Single(s => s.ExercicioId == id);
            return (T)obj;
        }

        public List<Exercicio> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.Exercicio.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as Exercicio;

            if (entityToSave != null) _repositoryContext.Exercicio.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
