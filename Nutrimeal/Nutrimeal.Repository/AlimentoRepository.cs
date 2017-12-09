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
    public class AlimentoRepository : IAlimentoRepository
    {

        private readonly RepositoryContext _repositoryContext;

        public AlimentoRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public AlimentoRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as Alimento;
            if (entityToSave != null)
            {
                var remAlimento = _repositoryContext.Alimento.Single(s => s.AlimentoId == entityToSave.AlimentoId);

                _repositoryContext.Alimento.Remove(remAlimento);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as Alimento;
            var entityInDb = _repositoryContext.Alimento.Single(o => o.AlimentoId == entityToUpdate.AlimentoId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Nome = entityToUpdate.Nome;
                entityInDb.Calorias = entityToUpdate.Calorias;
                entityInDb.Gordura = entityToUpdate.Gordura;
                entityInDb.Colestrol = entityToUpdate.Colestrol;
                entityInDb.Sodio = entityToUpdate.Sodio;
                entityInDb.Potassio = entityToUpdate.Potassio;

                entityInDb.Carboidrato = entityToUpdate.Carboidrato;
                entityInDb.Fibra = entityToUpdate.Fibra;
                entityInDb.Acucar = entityToUpdate.Acucar;
                entityInDb.Proteina = entityToUpdate.Proteina;
                entityInDb.Grupo = entityToUpdate.Grupo;


                _repositoryContext.Alimento.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.Alimento.Single(s => s.AlimentoId == id);
            return (T)obj;
        }

        public List<Alimento> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.Alimento.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as Alimento;

            if (entityToSave != null) _repositoryContext.Alimento.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void EditCaloriasAlimento<T>(T entity)
        {
            var entityToUpdate = entity as Alimento;
            var entityInDb = _repositoryContext.Alimento.Single(o => o.AlimentoId == entityToUpdate.AlimentoId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;


                entityInDb.Calorias = entityToUpdate.Calorias;

                _repositoryContext.Alimento.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }
    }
}
