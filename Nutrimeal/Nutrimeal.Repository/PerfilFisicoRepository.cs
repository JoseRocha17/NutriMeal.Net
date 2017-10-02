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
    public class PerfilFisicoRepository : IPerfilFisicoRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public PerfilFisicoRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public PerfilFisicoRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as PerfilFisico;
            if (entityToSave != null)
            {
                var remPerfilFisico = _repositoryContext.PerfilFisico.Single(s => s.PerfilFisicoId == entityToSave.PerfilFisicoId);

                _repositoryContext.PerfilFisico.Remove(remPerfilFisico);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as PerfilFisico;
            var entityInDb = _repositoryContext.PerfilFisico.Single(o => o.PerfilFisicoId == entityToUpdate.PerfilFisicoId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Nome = entityToUpdate.Nome;
                entityInDb.Data = entityToUpdate.Data;




                _repositoryContext.PerfilFisico.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.PerfilFisico.Single(s => s.PerfilFisicoId == id);
            return (T)obj;
        }

        public List<PerfilFisico> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.PerfilFisico.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as PerfilFisico;

            if (entityToSave != null) _repositoryContext.PerfilFisico.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
