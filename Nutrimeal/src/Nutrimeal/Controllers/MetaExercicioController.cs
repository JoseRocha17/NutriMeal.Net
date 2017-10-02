using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.MetaExercicio;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;
using Nutrimeal.Models.Exercicio;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class MetaExercicioController : Controller
    {
        private readonly IMetaExercicioManager _metaExercicioManager;
        private readonly IExercicioManager _exercicioManager;
        private readonly IPerfilFisicoManager _perfilFisicoManager;
        private readonly IExercicioAtributoManager _exercicioAtributoManager;

        public MetaExercicioController(IMetaExercicioManager metaExercicioManager, IExercicioManager exercicioManager, IPerfilFisicoManager perfilFisicoManager, IExercicioAtributoManager exercicioAtributoManager)
        {
            _metaExercicioManager = metaExercicioManager;
            _exercicioManager = exercicioManager;
            _perfilFisicoManager = perfilFisicoManager;
            _exercicioAtributoManager = exercicioAtributoManager;
        }




        public IActionResult Index(Guid id)
        {
            var clvm = new MetaExercicioListViewModel { PageName = "Listagem de Meta Exercicios ", PerfilFisicoId=id };
            try
            {
                var metaExercicios = _metaExercicioManager.GetAll().Where(s=> s.PerfilFisicoId==id);

                var perfilFisico = _perfilFisicoManager.Get(id);

                clvm.PerfilFisicoNome = perfilFisico.Nome;

                foreach (var item in metaExercicios)
                {
                    var exercicio = _exercicioManager.Get(item.ExercicioId);

                    
                    clvm.Items.Add(new MetaExercicioInList
                    {
                        MetaExercicioId = item.MetaExercicioId,
                        Calorias = item.Calorias,
                        ExercicioNome = exercicio.Nome,
                        PerfilFisicoId = item.PerfilFisicoId,
                        ExercicioId = item.ExercicioId
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
        public IActionResult New(Guid idPerfilFisico)
        {

            var clvm = new NewMetaExercicioViewModel { PageName = "Listagem de Alimentos ", PerfilFisicoId=idPerfilFisico };
            try
            {
                var exercicios = _exercicioManager.GetAll();



                foreach (var item in exercicios)
                {
                    clvm.Items.Add(new ExercicioInList
                    {
                        ExercicioId = item.ExercicioId,
                        Nome = item.Nome,
                        
                    });

                }
                return View(clvm);
            }
            catch (Exception ex)
            {
                clvm.ErrorMessage = ex.Message;

                // TODO: Log error
            }


            return View(new NewMetaExercicioViewModel { PageName = "Novo Exercicio" });
        }

        [HttpPost]
        public IActionResult New([FromRoute] Guid id, [Bind(Prefix = "MetaExercicioInput")]MetaExercicioInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var idm = Guid.NewGuid();
                    input.MetaExercicioId = idm;
                    input.PerfilFisicoId = id;
                    _metaExercicioManager.Create(ServicesAutoMapperConfig.Mapped.Map<MetaExercicio>(input));
                    return RedirectToAction("Details/" + id, "PerfilFisico");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewMetaExercicioViewModel { MetaExercicioInput = input });
            }

        }




        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //var clvm = new EditMetaExercicioViewModel { PageName = "Listagem de Alimentos " };
            //try
            //{
            //    var exercicios = _exercicioManager.GetAll();



            //    foreach (var item in exercicios)
            //    {
            //        clvm.Items.Add(new ExercicioInList
            //        {
            //            ExercicioId = item.ExercicioId,
            //            Nome = item.Nome,

            //        });

            //    }
            //    return View(clvm);
            //}
            //catch (Exception ex)
            //{
            //    clvm.ErrorMessage = ex.Message;

            //    // TODO: Log error
            //}


            var metaExercicio = _metaExercicioManager.Get(id);
            if (metaExercicio == null)
                return null;
            var viewModel = new EditMetaExercicioViewModel
            {
                PageName = "Editar Exercicio",
                MetaExercicioOnList = ServicesAutoMapperConfig.Mapped.Map<MetaExercicioInList>(metaExercicio),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "MetaExercicioOnList")] MetaExercicioInList input)
        {
            if (ModelState.IsValid)
            {

                _metaExercicioManager.Edit(ServicesAutoMapperConfig.Mapped.Map<MetaExercicio>(input));
            }
            else
            {
                return View(new EditMetaExercicioViewModel
                {
                    MetaExercicioOnList = input
                });
            }
            return RedirectToAction("Index", "MetaExercicio");

        }

        public ActionResult Delete(Guid id)
        {

            var metaExercicio = _metaExercicioManager.Get(id);
            if (metaExercicio == null)
                return null;
            var viewModel = new DeleteMetaExercicioViewModel
            {
                PageName = "Apagar Meta Exercicio",
                MetaExercicioOnList = ServicesAutoMapperConfig.Mapped.Map<MetaExercicioInList>(metaExercicio),
            };

            return View("Delete", viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var metaExercicio = _metaExercicioManager.Get(id);
            var exercicioAtributo = _exercicioAtributoManager.GetAll();

            if (metaExercicio == null)
                return null;

            _metaExercicioManager.Delete(metaExercicio);
            _exercicioAtributoManager.DeleteMetaExercicioWithAtributo(id, exercicioAtributo);

            return RedirectToAction("Index", "MetaExercicio");
        }


        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var metaExercicio = _metaExercicioManager.Get(id);
            if (metaExercicio == null)
                return null;

            var idExercicio = metaExercicio.ExercicioId;

            var perfilFisico = _perfilFisicoManager.Get(metaExercicio.PerfilFisicoId);

            var exercicio = _exercicioManager.Get(idExercicio);
            var ViewModel = new DetailsMetaExercicioViewModel()
            {
                PageName = "Detalhes do Meta Exercicio",
                Exercicio = exercicio.Nome,
                PerfilFisicoNome = perfilFisico.Nome
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<MetaExercicioInList>(metaExercicio);

            return View("Details", ViewModel);
        }

    }



}