using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Web.Models;
using Nutrimeal.Web.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public partial class ObjetivosController : Controller
    {

        private readonly IObjetivosManager _objetivosManager;

        public ObjetivosController(IObjetivosManager objetivosManager)
        {
            _objetivosManager = objetivosManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var clvm = new ObjetivosListViewModel { PageName = "Listagem de Objetivos "};
            try
            {
                var objetivos = _objetivosManager.GetAll();



                foreach (var item in objetivos)
                {
                    clvm.Items.Add(new ObjetivosCreate
                    {
                        ObjetivosId = item.ObjetivosId,
                        Peso = item.Peso,
                        Pescoco = item.Pescoco,
                        Cintura = item.Cintura,
                        Quadris = item.Quadris,
                        DataObjetivo = item.DataObjetivo

                    });
                }
            }
            catch (Exception ex)
            {
                clvm.ErrorMessage = ex.Message;
                // TODO: Log error
            }

            return View(clvm);
        }

        [HttpGet]
        public IActionResult New()
        {

            return View(new NewObjetivoViewModel { PageName = "Novo Objetivo" });
        }

        [HttpPost]
        public IActionResult New([Bind(Prefix = "ObjetivoInput")]ObjetivosCreate input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var id = Guid.NewGuid();
                    input.ObjetivosId = id;
                    _objetivosManager.Create(ServicesAutoMapperConfig.Mapped.Map<Nutrimeal.Models.Objetivos>(input));
                    return RedirectToAction("Index", "Objetivos");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewObjetivoViewModel { ObjetivoInput = input });
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var objetivo = _objetivosManager.Get(id);
            if (objetivo == null)
                return null;
            var viewModel = new EditObjetivoViewModel
            {
                PageName = "Editar Objetivo",
                ObjetivoInList = ServicesAutoMapperConfig.Mapped.Map<ObjetivosList>(objetivo),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "ObjetivoInList")] ObjetivosList input)
        {
            if (ModelState.IsValid)
            {

                _objetivosManager.Edit(ServicesAutoMapperConfig.Mapped.Map<Nutrimeal.Models.Objetivos>(input));
            }
            else
            {
                return View(new EditObjetivoViewModel
                {
                    ObjetivoInList = input
                });
            }
            return RedirectToAction("Index", "Objetivos");

        }


        // GET: Course/Delete/5
        public ActionResult Delete(Guid id)
        {

            var objetivo = _objetivosManager.Get(id);
            if (objetivo == null)
                return null;
            var viewModel = new DeleteObjetivoViewModel
            {
                PageName = "Apagar Objetivo",
                ObjetivoInList = ServicesAutoMapperConfig.Mapped.Map<ObjetivosList>(objetivo),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var objetivo = _objetivosManager.Get(id);

            if (objetivo == null)
                return null;

            _objetivosManager.Delete(objetivo);

            return RedirectToAction("Index", "Objetivos");
        }


        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var objetivo = _objetivosManager.Get(id);
            if (objetivo == null)
                return null;
            var ViewModel = new DetailsObjetivoViewModel()
            {
                PageName = "Detalhes do Objetivo",
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<Nutrimeal.Web.Models.ObjetivosList>(objetivo);

            return View("Details", ViewModel);
        }

    }
}
