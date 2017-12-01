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
    public class RefeicaoRepository : IRefeicaoRepository
    {

        private readonly RepositoryContext _repositoryContext;

        public RefeicaoRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public RefeicaoRepository()
        {
            _repositoryContext = new RepositoryContext();
        }

        public void Delete<T>(T entity)
        {
            var entityToSave = entity as Refeicao;
            if (entityToSave != null)
            {
                var remRefeicao = _repositoryContext.Refeicao.Single(s => s.RefeicaoId == entityToSave.RefeicaoId);

                _repositoryContext.Refeicao.Remove(remRefeicao);
                _repositoryContext.SaveChanges();
            }
        }

        public void Edit<T>(T entity)
        {
            var entityToUpdate = entity as Refeicao;
            var entityInDb = _repositoryContext.Refeicao.Single(o => o.RefeicaoId == entityToUpdate.RefeicaoId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.Nome = entityToUpdate.Nome;
                entityInDb.TotalCalorias = entityToUpdate.TotalCalorias;




                _repositoryContext.Refeicao.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public void EditCaloriasRefeicao<T>(T entity)
        {
            var entityToUpdate = entity as Refeicao;
            var entityInDb = _repositoryContext.Refeicao.Single(o => o.RefeicaoId == entityToUpdate.RefeicaoId);
            if (entityInDb != null)
            {
                entityInDb.ModifiedAt = DateTime.Now;

                entityInDb.TotalCalorias = entityToUpdate.TotalCalorias;




                _repositoryContext.Refeicao.Update(entityInDb);
                _repositoryContext.SaveChanges();
            }
        }

        public T Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Guid id)
        {
            object obj = _repositoryContext.Refeicao.Single(s => s.RefeicaoId == id);
            return (T)obj;
        }

        public List<Refeicao> GetAll(int page = 0, int howMany = 20)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _repositoryContext.Refeicao.AsNoTracking().ToList() as List<T>;
        }

        public void Save<T>(T entity)
        {
            var entityToSave = entity as Refeicao;

            if (entityToSave != null) _repositoryContext.Refeicao.Add(entityToSave);

            _repositoryContext.SaveChanges();
        }

        public Task SaveAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
