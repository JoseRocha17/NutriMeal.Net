using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.Atributo;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class AtributoController : Controller
    {


        private readonly IAtributoManager _atributoManager;

        public AtributoController(IAtributoManager atributoManager)
        {
            _atributoManager = atributoManager;
        }


        public IActionResult Index()
        {
            var clvm = new AtributoListViewModel { PageName = "Listagem de Atributos " };
            try
            {
                var atributos = _atributoManager.GetAll();



                foreach (var item in atributos)
                {
                    clvm.Items.Add(new AtributoInList
                    {
                        AtributoId = item.AtributoId,
                        Nome = item.Nome
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

            return View(new NewAtributoViewModel { PageName = "Novo Atributo" });
        }

        [HttpPost]
        public IActionResult New([Bind(Prefix = "AtributoInput")]AtributoInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var id = Guid.NewGuid();
                    input.AtributoId = id;
                    _atributoManager.Create(ServicesAutoMapperConfig.Mapped.Map<Atributo>(input));
                    return RedirectToAction("Index", "Atributo");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewAtributoViewModel { AtributoInput = input });
            }

        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var atributo = _atributoManager.Get(id);
            if (atributo == null)
                return null;
            var viewModel = new EditAtributoViewModel
            {
                PageName = "Editar Atributo",
                AtributoToEdit = ServicesAutoMapperConfig.Mapped.Map<AtributoInList>(atributo),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "AtributoToEdit")] AtributoInList input)
        {
            if (ModelState.IsValid)
            {

                _atributoManager.Edit(ServicesAutoMapperConfig.Mapped.Map<Atributo>(input));
            }
            else
            {
                return View(new EditAtributoViewModel
                {
                    AtributoToEdit = input
                });
            }
            return RedirectToAction("Index", "Atributo");

        }

        public ActionResult Delete(Guid id)
        {

            var atributo = _atributoManager.Get(id);
            if (atributo == null)
                return null;
            var viewModel = new DeleteAtributoViewModel
            {
                PageName = "Apagar Atributo",
                AtributoToDelete = ServicesAutoMapperConfig.Mapped.Map<AtributoInList>(atributo),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var atributo = _atributoManager.Get(id);

            if (atributo == null)
                return null;

            _atributoManager.Delete(atributo);

            return RedirectToAction("Index", "Atributo");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var atributo = _atributoManager.Get(id);
            if (atributo == null)
                return null;
            var ViewModel = new DetailsAtributoViewModel()
            {
                PageName = "Detalhes do Atributo",
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<AtributoInList>(atributo);

            return View("Details", ViewModel);
        }

    }
}
