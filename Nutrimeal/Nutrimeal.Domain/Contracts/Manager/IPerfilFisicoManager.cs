using Nutrimeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrimeal.Domain.Contracts.Manager
{
    public interface IPerfilFisicoManager
    {
        Guid Create(Models.PerfilFisico perfilFisico);
        Task CreateAsync(PerfilFisico perfilFisico);
        void Edit(Models.PerfilFisico perfilFisico);
        Guid Delete(Models.PerfilFisico perfilFisico);
        Models.PerfilFisico Get(Guid id);
        //List<Objetivos> GetAll(Guid id);
        List<Models.PerfilFisico> GetAll();

    }
}
