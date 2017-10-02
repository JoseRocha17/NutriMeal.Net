using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.PerfilFisico;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;
using Microsoft.AspNetCore.Identity;
using Nutrimeal.Models.MetaExercicio;
using Nutrimeal.Models.ExercicioAtributo;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class PerfilFisicoController : Controller
    {
        private readonly IPerfilFisicoManager _perfilFisicoManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMetaExercicioManager _metaExercicioManager;
        private readonly IExercicioManager _exercicioManager;
        private readonly IExercicioAtributoManager _exercicioAtributoManager;
        private readonly IAtributoManager _atributoManager;

        public PerfilFisicoController(IPerfilFisicoManager perfilFisicoManager, UserManager<ApplicationUser> userManager, IMetaExercicioManager metaExercicioManager, IExercicioManager exercicioManager, IExercicioAtributoManager exercicioAtributoManager, IAtributoManager atributoManager)
        {
            _perfilFisicoManager = perfilFisicoManager;
            _userManager = userManager;
            _metaExercicioManager = metaExercicioManager;
            _exercicioManager = exercicioManager;
            _exercicioAtributoManager = exercicioAtributoManager;
            _atributoManager = atributoManager;
        }
        //Utilizador


        // GET: /<controller>/
        public async Task<IActionResult> Index(string id)
        {
            var clvm = new PerfilFisicoListViewModel { PageName = "Listagem de Perfis Físicos " };
            //var user = await GetUserById(id);
            //clvm.UserEmail = user.Email;

            try
            {
                var perfisFisicos = _perfilFisicoManager.GetAll().Where(x=>x.UserId==id).OrderBy(x=> x.Data);

                

                foreach (var item in perfisFisicos)
                {

                    var user = await GetUserById(item.UserId);

                    clvm.Items.Add(new PerfilFisicoInList
                    {
                        PerfilFisicoId = item.PerfilFisicoId,
                        Nome = item.Nome,
                        Data = item.Data,
                        UserEmail = user.Email

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
        public IActionResult New(string id)
        {

            return View(new NewPerfilFisicoViewModel { PageName = "Novo Perfil Fisico", UserId = id });
        }

        [HttpPost]
        public IActionResult New([FromRoute] string id, [Bind(Prefix = "PerfilFisicoInput")]PerfilFisicoInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var idp = Guid.NewGuid();
                    input.PerfilFisicoId = idp;
                    input.UserId = id;
                    _perfilFisicoManager.Create(ServicesAutoMapperConfig.Mapped.Map<PerfilFisico>(input));
                    return RedirectToAction("Index/" + id, "PerfilFisico");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewPerfilFisicoViewModel { PerfilFisicoInput = input });
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var perfilFisico = _perfilFisicoManager.Get(id);
            if (perfilFisico == null)
                return null;
            var viewModel = new EditPerfilFisicoViewModel
            {
                PageName = "Editar Perfil Físico",
                PerfilInList = ServicesAutoMapperConfig.Mapped.Map<PerfilFisicoInList>(perfilFisico),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "PerfilInList")] PerfilFisicoInList input)
        {
            if (ModelState.IsValid)
            {

                _perfilFisicoManager.Edit(ServicesAutoMapperConfig.Mapped.Map<PerfilFisico>(input));
            }
            else
            {
                return View(new EditPerfilFisicoViewModel
                {
                    PerfilInList = input
                });
            }
            return RedirectToAction("Index", "PerfilFisico");

        }

        public ActionResult Delete(Guid id)
        {

            var perfilFisico = _perfilFisicoManager.Get(id);
            if (perfilFisico == null)
                return null;
            var viewModel = new DeletePerfilFisicoViewModel
            {
                PageName = "Apagar Perfil Físico",
                PerfilFisicoOnList = ServicesAutoMapperConfig.Mapped.Map<PerfilFisicoInList>(perfilFisico),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var perfilFisico = _perfilFisicoManager.Get(id);

            if (perfilFisico == null)
                return null;

            _perfilFisicoManager.Delete(perfilFisico);

            return RedirectToAction("Index", "PerfilFisico");
        }

        [HttpGet]
        public IActionResult Details(Guid id, Guid? MetaExercicioId, string MetaExercicioNome )
        {
            var perfilFisico = _perfilFisicoManager.Get(id);
            //var metaExercicios = _metaExercicioManager.GetAll().Where(x=>x.PerfilFisicoId==id);
            var ViewModel = new DetailsPerfilFisicoViewModel()
            {
                PageName = "Detalhes do Perfil Físico",
            };

            if (MetaExercicioId != null)
            {
                ViewBag.MetaExercicioId = MetaExercicioId.Value;

                ViewBag.MetaExercicioNome = MetaExercicioNome;

                ViewModel.MetaExercicioNome = MetaExercicioNome;

                var exercicioAtributos = _exercicioAtributoManager.GetAll().Where(x => x.MetaExercicioId == MetaExercicioId);
                foreach (var item in exercicioAtributos)
                {

                    var atributo = _atributoManager.Get(item.AtributoId);
                    ViewModel.ExercicioAtributos.Add(new ExercicioAtributoInList
                    {
                        ExercicioAtributoId = item.ExercicioAtributoId,
                        MetaExercicioId = item.MetaExercicioId,
                        AtributoId = item.AtributoId,
                        Valor = item.Valor,
                        AtributoNome = atributo.Nome
                    });

                }  

                //foreach(var item2 in ViewModel.ExercicioAtributos)
                //{
                //   var atributoFirst = _atributoManager.Get(item.AtributoId);
                //    ViewModel.AtributoNome = atributo.Nome;

                //}
            }

            try
            {
                var metaExercicios = _metaExercicioManager.GetAll().Where(s => s.PerfilFisicoId == id);

                //var perfilFisico = _perfilFisicoManager.Get(id);

                //clvm.PerfilFisicoNome = perfilFisico.Nome;

                foreach (var item in metaExercicios)
                {
                    var exercicio = _exercicioManager.Get(item.ExercicioId);


                    ViewModel.Items.Add(new MetaExercicioInList
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
                ViewModel.ErrorMessage = ex.Message;
                // TODO: Log error
            }


            if (perfilFisico == null)
                return null;


            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<PerfilFisicoInList>(perfilFisico);

            return View("Details", ViewModel);
        }

        private async Task<ApplicationUser> GetUserById(string id) => await _userManager.FindByIdAsync(id);


        //Admnistrador

        // GET: /<controller>/
        public async Task<IActionResult> AdminList(string id)
        {
            var clvm = new PerfilFisicoListViewModel { PageName = "Listagem de Perfis Físicos " };
            //var user = await GetUserById(id);
            //clvm.UserEmail = user.Email;


            try
            {
                var perfisFisicos = _perfilFisicoManager.GetAll().OrderBy(x=>x.Data);



                foreach (var item in perfisFisicos)
                {

                    var user = await GetUserById(item.UserId);

                    clvm.Items.Add(new PerfilFisicoInList
                    {
                        PerfilFisicoId = item.PerfilFisicoId,
                        Nome = item.Nome,
                        Data = item.Data,
                        UserEmail = user.Email

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
        public IActionResult NewPerfilFisicoAdmin(string id)
        {

            return View(new NewPerfilFisicoViewModel { PageName = "Novo Perfil Fisico", UserId = id });
        }

        [HttpPost]
        public IActionResult NewPerfilFisicoAdmin([FromRoute] string id, [Bind(Prefix = "PerfilFisicoInput")]PerfilFisicoInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var idp = Guid.NewGuid();
                    input.PerfilFisicoId = idp;
                    input.UserId = id;
                    _perfilFisicoManager.Create(ServicesAutoMapperConfig.Mapped.Map<PerfilFisico>(input));
                    return RedirectToAction("AdminList", "PerfilFisico");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewPerfilFisicoViewModel { PerfilFisicoInput = input });
            }

        }


        public ActionResult DeletePerfilFisicoAdmin(Guid id)
        {

            var perfilFisico = _perfilFisicoManager.Get(id);
            if (perfilFisico == null)
                return null;
            var viewModel = new DeletePerfilFisicoViewModel
            {
                PageName = "Apagar Perfil Físico",
                PerfilFisicoOnList = ServicesAutoMapperConfig.Mapped.Map<PerfilFisicoInList>(perfilFisico),
            };

            return View("DeletePerfilFisicoAdmin", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("DeletePerfilFisicoAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedAdmin(Guid id)
        {
            var perfilFisico = _perfilFisicoManager.Get(id);

            if (perfilFisico == null)
                return null;

            _perfilFisicoManager.Delete(perfilFisico);

            return RedirectToAction("AdminList", "PerfilFisico");
        }



    }
}
