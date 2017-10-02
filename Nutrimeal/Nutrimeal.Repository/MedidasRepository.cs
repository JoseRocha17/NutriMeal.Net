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
    public class MedidasRepository : IMedidasRepository
    {

        private readonly RepositoryContext _repositoryContext;

        public MedidasRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public MedidasRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as Medidas;
            if (entityToSave != null)
            {
                var remMedida = _repositoryContext.Medidas.Single(s => s.MedidaId == entityToSave.MedidaId);

                _repositoryContext.Medidas.Remove(remMedida);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as Medidas;
            var entityInDb = _repositoryContext.Medidas.Single(o => o.MedidaId == entityToUpdate.MedidaId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Altura = entityToUpdate.Altura;
                entityInDb.Peso = entityToUpdate.Peso;
                entityInDb.Pescoco = entityToUpdate.Pescoco;
                entityInDb.Cintura = entityToUpdate.Cintura;
                entityInDb.Quadris = entityToUpdate.Quadris;
                entityInDb.DataMedicao = entityToUpdate.DataMedicao;


                _repositoryContext.Medidas.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.Medidas.Single(s => s.MedidaId == id);
            return (T)obj;
        }

        public List<Medidas> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.Medidas.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as Medidas;

            if (entityToSave != null) _repositoryContext.Medidas.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
