using System;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.ExercicioAtributo;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;
using System.Linq;
using Nutrimeal.Models.Atributo;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class ExercicioAtributoController : Controller
    {


        private readonly IExercicioAtributoManager _exercicioAtributoManager;
        private readonly IAtributoManager _atributoManager;
        private readonly IExercicioManager _exercicioManager;
        private readonly IMetaExercicioManager _metaExercicioManager;
        private readonly IPerfilFisicoManager _perfilFisicoManager;

        public ExercicioAtributoController(IExercicioAtributoManager exercicioAtributoManager, IAtributoManager atributoManager, IExercicioManager exercicioManager, IMetaExercicioManager metaExercicioManager, IPerfilFisicoManager perfilFisicoManager)
        {
            _exercicioAtributoManager = exercicioAtributoManager;
            _atributoManager = atributoManager;
            _exercicioManager = exercicioManager;
            _metaExercicioManager = metaExercicioManager;
            _perfilFisicoManager = perfilFisicoManager;
        }

        // GET: /<controller>/
        public IActionResult Index(Guid id)
        {
            var clvm = new ExercicioAtributoListViewModel { PageName = "Listagem de Exercicios Atributos ", MetaExercicioId=id };
            try
            {
                var exercicioAtributos = _exercicioAtributoManager.GetAll().Where(s=>s.MetaExercicioId==id);

                var metaExercicio = _metaExercicioManager.Get(id);
                var exercicio = _exercicioManager.Get(metaExercicio.ExercicioId);

                clvm.ExercicioNome = exercicio.Nome;

                foreach (var item in exercicioAtributos)
                {

                    var atributo = _atributoManager.Get(item.AtributoId);
                    clvm.Items.Add(new ExercicioAtributoInList
                    {
                        ExercicioAtributoId = item.ExercicioAtributoId,
                        MetaExercicioId = item.MetaExercicioId,
                        AtributoId = item.AtributoId,
                        Valor = item.Valor,
                        AtributoNome = atributo.Nome
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
        public IActionResult New(Guid id)
        {
            var clvm = new NewExercicioAtributoViewModel {};

            try
            {
                var atributos = _atributoManager.GetAll();

                foreach(var item in atributos)
                {
                    clvm.Items.Add(new AtributoInList
                    {
                        AtributoId = item.AtributoId,
                        Nome = item.Nome
                    });
                }
                return View(clvm);
            }
            catch (Exception ex)
            {
                clvm.ErrorMessage = ex.Message;

                // TODO: Log error
            }



            return View(new NewExercicioAtributoViewModel { PageName = "Novo Exercicio Atributo", MetaExercicioId=id});
        }

        [HttpPost]
        public IActionResult New([FromRoute] Guid id, [Bind(Prefix = "ExercicioAtributoInput")]ExercicioAtributoInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var ide = Guid.NewGuid();
                    input.ExercicioAtributoId = ide;
                    input.MetaExercicioId = id;
                    _exercicioAtributoManager.Create(ServicesAutoMapperConfig.Mapped.Map<ExercicioAtributo>(input));

                    var metaExercicio = _metaExercicioManager.Get(id);
                    var perfilFisico = _perfilFisicoManager.Get(metaExercicio.PerfilFisicoId);
                    return RedirectToAction("Details/" + perfilFisico.PerfilFisicoId, "PerfilFisico");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewExercicioAtributoViewModel { ExercicioAtributoInput = input });
            }

        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var exercicioAtributo = _exercicioAtributoManager.Get(id);
            if (exercicioAtributo == null)
                return null;
            var viewModel = new EditExercicioAtributoViewModel
            {
                PageName = "Editar Exercicio Atributo",
                ExercicioAtributoToEdit = ServicesAutoMapperConfig.Mapped.Map<ExercicioAtributoInList>(exercicioAtributo),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "ExercicioAtributoToEdit")] ExercicioAtributoInList input)
        {
            if (ModelState.IsValid)
            {

                _exercicioAtributoManager.Edit(ServicesAutoMapperConfig.Mapped.Map<ExercicioAtributo>(input));
            }
            else
            {
                return View(new EditExercicioAtributoViewModel
                {
                    ExercicioAtributoToEdit = input
                });
            }
            return RedirectToAction("Index", "ExercicioAtributo");

        }

        public ActionResult Delete(Guid id)
        {

            var exercicioAtributo = _exercicioAtributoManager.Get(id);
            if (exercicioAtributo == null)
                return null;
            var viewModel = new DeleteExercicioAtributoViewModel
            {
                PageName = "Apagar Exercicio Atributo",
                ExercicioAtributoToDelete = ServicesAutoMapperConfig.Mapped.Map<ExercicioAtributoInList>(exercicioAtributo),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var exercicioAtributo = _exercicioAtributoManager.Get(id);

            if (exercicioAtributo == null)
                return null;

            _exercicioAtributoManager.Delete(exercicioAtributo);

            return RedirectToAction("Index", "ExercicioAtributo");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {

            var exercicioAtributo = _exercicioAtributoManager.Get(id);

            var metaExercicio = _metaExercicioManager.Get(exercicioAtributo.MetaExercicioId);

            var exercicio = _exercicioManager.Get(metaExercicio.ExercicioId);

            var atributo = _atributoManager.Get(exercicioAtributo.AtributoId);


            if (exercicioAtributo == null)
                return null;
            var ViewModel = new DetailsExercicioAtributoViewModel()
            {
                PageName = "Detalhes do Exercicio Atributo",
                ExercicioNome = exercicio.Nome,
                AtributoNome = atributo.Nome

            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<ExercicioAtributoInList>(exercicioAtributo);

            return View("Details", ViewModel);
        }


    }
}
