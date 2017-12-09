using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.Alimento;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class AlimentoController : Controller
    {
        private readonly IAlimentoManager _alimentoManager;

        public AlimentoController(IAlimentoManager alimentoManager)
        {
            _alimentoManager = alimentoManager;
        }


        public IActionResult Index()
        {
            var clvm = new AlimentoListViewModel { PageName = "Listagem de Alimentos " };
            try
            {
                var alimentos = _alimentoManager.GetAll();



                foreach (var item in alimentos)
                {
                    clvm.Items.Add(new AlimentoInList
                    {
                      AlimentoId = item.AlimentoId,
                      Nome = item.Nome,
                      Calorias = item.Calorias,
                      Gordura = item.Gordura,
                      Colestrol = item.Colestrol,
                      Sodio = item.Sodio,
                      Potassio = item.Potassio,
                      Carboidrato = item.Carboidrato,
                      Fibra = item.Fibra,
                      Acucar = item.Acucar,
                      Proteina = item.Proteina,
                      Grupo = item.Grupo
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

            return View(new NewAlimentoViewModel { PageName = "Novo Alimento" });
        }

        [HttpPost]
        public IActionResult New([Bind(Prefix = "AlimentoInput")]AlimentoInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var id = Guid.NewGuid();
                    input.AlimentoId = id;
                    _alimentoManager.Create(ServicesAutoMapperConfig.Mapped.Map<Alimento>(input));
                    return RedirectToAction("Index", "Alimento");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewAlimentoViewModel { AlimentoInput = input });
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var alimento = _alimentoManager.Get(id);
            if (alimento == null)
                return null;
            var viewModel = new EditAlimentoViewModel
            {
                PageName = "Editar Alimento",
                AlimentoToUpdate = ServicesAutoMapperConfig.Mapped.Map<AlimentoInList>(alimento),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "AlimentoToUpdate")] AlimentoInList input)
        {
            if (ModelState.IsValid)
            {

                _alimentoManager.Edit(ServicesAutoMapperConfig.Mapped.Map<Alimento>(input));
            }
            else
            {
                return View(new EditAlimentoViewModel
                {
                    AlimentoToUpdate = input
                });
            }
            return RedirectToAction("Index", "Alimento");

        }


        [HttpPost]
        public IActionResult EditAlimentoCalorias([Bind(Prefix = "AlimentoToUpdate")] AlimentoInList input)
        {
            if (ModelState.IsValid)
            {

                _alimentoManager.EditCaloriasAlimento(ServicesAutoMapperConfig.Mapped.Map<Alimento>(input));
            }
            else
            {
                return View(new DetailsAlimentoViewModel
                {
                    AlimentoToUpdate = input
                });
            }

            //var refeicao = _refeicaoManager.Get(input.RefeicaoId);
            //var perfilAlimentar = _perfilAlimentarManager.Get(refeicao.PerfilAlimentarId);
            var alimentoId = input.AlimentoId;


            return RedirectToAction("Details/" + alimentoId, "Alimento");

        }

        public ActionResult Delete(Guid id)
        {

            var alimento = _alimentoManager.Get(id);
            if (alimento == null)
                return null;
            var viewModel = new DeleteAlimentoViewModel
            {
                PageName = "Apagar Alimento",
                AlimentoToDelete = ServicesAutoMapperConfig.Mapped.Map<AlimentoInList>(alimento),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var alimento = _alimentoManager.Get(id);

            if (alimento == null)
                return null;

            _alimentoManager.Delete(alimento);

            return RedirectToAction("Index", "Alimento");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var alimento = _alimentoManager.Get(id);
            if (alimento == null)
                return null;
            var ViewModel = new DetailsAlimentoViewModel()
            {
                PageName = "Detalhes do Alimento",
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<AlimentoInList>(alimento);

            return View("Details", ViewModel);
        }



    }
}
