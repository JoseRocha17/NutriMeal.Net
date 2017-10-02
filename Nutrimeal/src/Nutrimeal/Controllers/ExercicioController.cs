using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.Exercicio;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class ExercicioController : Controller
    {
        private readonly IExercicioManager _exercicioManager;

        public ExercicioController(IExercicioManager exercicioManager)
        {
            _exercicioManager = exercicioManager;
        }


        public IActionResult Index()
        {
            var clvm = new ExercicioListViewModel { PageName = "Listagem de Exercicios " };
            try
            {
                var exercicios = _exercicioManager.GetAll();



                foreach (var item in exercicios)
                {
                    clvm.Items.Add(new ExercicioInList
                    {
                        ExercicioId = item.ExercicioId,
                        Nome = item.Nome,
                        Tipo = item.Tipo,
                        Descricao = item.Descricao
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

            return View(new NewExercicioViewModel { PageName = "Novo Exercicio" });
        }

        [HttpPost]
        public IActionResult New([Bind(Prefix = "ExercicioInput")]ExercicioInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var id = Guid.NewGuid();
                    input.ExercicioId = id;
                    _exercicioManager.Create(ServicesAutoMapperConfig.Mapped.Map<Exercicio>(input));
                    return RedirectToAction("Index", "Exercicio");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewExercicioViewModel { ExercicioInput = input });
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var exercicio = _exercicioManager.Get(id);
            if (exercicio == null)
                return null;
            var viewModel = new EditExercicioViewModel
            {
                PageName = "Editar Exercicio",
                ExercicioOnList = ServicesAutoMapperConfig.Mapped.Map<ExercicioInList>(exercicio),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "ExercicioOnList")] ExercicioInList input)
        {
            if (ModelState.IsValid)
            {

                _exercicioManager.Edit(ServicesAutoMapperConfig.Mapped.Map<Exercicio>(input));
            }
            else
            {
                return View(new EditExercicioViewModel
                {
                    ExercicioOnList = input
                });
            }
            return RedirectToAction("Index", "Exercicio");

        }

        public ActionResult Delete(Guid id)
        {

            var exercicio = _exercicioManager.Get(id);
            if (exercicio == null)
                return null;
            var viewModel = new DeleteExercicioViewModel
            {
                PageName = "Apagar Exercicio",
                ExercicioOnList = ServicesAutoMapperConfig.Mapped.Map<ExercicioInList>(exercicio),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var exercicio = _exercicioManager.Get(id);

            if (exercicio == null)
                return null;

            _exercicioManager.Delete(exercicio);

            return RedirectToAction("Index", "Exercicio");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var exercicio = _exercicioManager.Get(id);
            if (exercicio == null)
                return null;
            var ViewModel = new DetailsExercicioViewModel()
            {
                PageName = "Detalhes do Exercicio",
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<ExercicioInList>(exercicio);

            return View("Details", ViewModel);
        }

    }
}
