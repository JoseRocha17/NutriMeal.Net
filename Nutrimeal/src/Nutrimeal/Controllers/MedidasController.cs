using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Web.Models.Medidas;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class MedidasController : Controller
    {

        private readonly IMedidasManager _medidasManager;

        public MedidasController(IMedidasManager medidasManager)
        {
            _medidasManager = medidasManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var clvm = new MedidasListViewModel { PageName = "Listagem de Medidas " };
            try
            {
                var medidas = _medidasManager.GetAll();



                foreach (var item in medidas)
                {
                    clvm.Items.Add(new MedidasInList
                    {
                        MedidaId = item.MedidaId,
                        Altura = item.Altura,
                        Peso = item.Peso,
                        Pescoco = item.Pescoco,
                        Cintura = item.Cintura,
                        Quadris = item.Quadris,
                        DataMedicao = item.DataMedicao

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

            return View(new NewMedidaViewModel { PageName = "Nova Medida" });
        }

        [HttpPost]
        public IActionResult New([Bind(Prefix = "MedidaInput")]MedidasInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var id = Guid.NewGuid();
                    input.MedidaId = id;
                    _medidasManager.Create(ServicesAutoMapperConfig.Mapped.Map<Medidas>(input));
                    return RedirectToAction("Index", "Medidas");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewMedidaViewModel { MedidaInput = input });
            }

        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var medida = _medidasManager.Get(id);
            if (medida == null)
                return null;
            var viewModel = new EditMedidaViewModel
            {
                PageName = "Editar Medição",
                MedidaInList = ServicesAutoMapperConfig.Mapped.Map<MedidasInList>(medida),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "MedidaInList")] MedidasInList input)
        {
            if (ModelState.IsValid)
            {

                _medidasManager.Edit(ServicesAutoMapperConfig.Mapped.Map<Nutrimeal.Models.Medidas>(input));
            }
            else
            {
                return View(new EditMedidaViewModel
                {
                    MedidaInList = input
                });
            }
            return RedirectToAction("Index", "Medidas");

        }


        public ActionResult Delete(Guid id)
        {

            var medida = _medidasManager.Get(id);
            if (medida == null)
                return null;
            var viewModel = new DeleteMedidaViewModel
            {
                PageName = "Apagar Medição",
                MedidaInList = ServicesAutoMapperConfig.Mapped.Map<MedidasInList>(medida),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var medida = _medidasManager.Get(id);

            if (medida == null)
                return null;

            _medidasManager.Delete(medida);

            return RedirectToAction("Index", "Medidas");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var medida = _medidasManager.Get(id);
            if (medida == null)
                return null;
            var ViewModel = new DetailsMedidaViewModel()
            {
                PageName = "Detalhes da Medição",
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<MedidasInList>(medida);

            return View("Details", ViewModel);
        }





    }
}
