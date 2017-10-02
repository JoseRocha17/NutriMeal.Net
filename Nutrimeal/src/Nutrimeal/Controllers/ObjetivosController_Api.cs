using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Models.API;
using Nutrimeal.Web.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public partial class ObjetivosController : Controller
    {
        [HttpGet, Route("API/Objetivos/List")]
        public PagedSet<ObjetivosList> ListObjetivos()
        {
            var result = new PagedSet<ObjetivosList>();

            try
            {
                var objetivos = _objetivosManager.GetAll();

                var tmp = objetivos.Select(item => new ObjetivosList
                {
                    ObjetivosId = item.ObjetivosId,
                    Peso = item.Peso,
                    Pescoco = item.Pescoco,
                    Cintura = item.Cintura,
                    Quadris = item.Quadris,
                    DataObjetivo = item.DataObjetivo
                })
                    .ToList();

                result.Items = tmp;
                result.Total = tmp.Count;
                result.HasMore = result.Total > result.Items.Count();

            }
            catch (Exception ex)
            {
                // TODO :Logging
                result.HasMore = true;
                result.HasError = true;
                result.Message = ex.Message;
            }

            return result;
        }

    }
}
