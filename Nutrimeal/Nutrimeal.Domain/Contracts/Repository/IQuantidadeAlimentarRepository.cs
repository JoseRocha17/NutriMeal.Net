﻿using Nutrimeal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Repository
{
    public interface IQuantidadeAlimentarRepository : IRepositoryBase
    {
        void Edit<T>(T entity);
        T Get<T>(Guid id);
        List<QuantidadeAlimentar> GetAll(int page = 0, int howMany = 20);
    }
}
