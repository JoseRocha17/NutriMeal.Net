using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.PerfilAlimentar;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class PerfilAlimentarController : Controller
    {

        private readonly IPerfilAlimentarManager _perfilAlimentarManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public PerfilAlimentarController(IPerfilAlimentarManager perfilAlimentarManager, UserManager<ApplicationUser> userManager)
        {
            _perfilAlimentarManager = perfilAlimentarManager;
            _userManager = userManager;
        }
       //Utilizador


        // GET: /<controller>/
        public async Task<IActionResult> Index(string id)
        {
            var clvm = new PerfilAlimentarListViewModel { PageName = "Listagem de Perfis Alimentares " };
            try
            {
                var perfisAlimentares = _perfilAlimentarManager.GetAll().Where(x=>x.UserId==id).OrderBy(x=>x.Data);


               // var user = await GetUserById(id);

                //clvm.UserEmail = user.Email;
                foreach (var item in perfisAlimentares)
                {

                    var user = await GetUserById(item.UserId);
                    clvm.Items.Add(new PerfilAlimentarInList
                    {

                        PerfilAlimentarId = item.PerfilAlimentarId,
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

            return View(new NewPerfilAlimentarViewModel { PageName = "Novo PerfilAlimentar", UserId=id });
        }

        [HttpPost]
        public IActionResult New([FromRoute] string id, [Bind(Prefix = "PerfilAlimentarInput")]PerfilAlimentarInList input)
        {
        
            if (ModelState.IsValid)
            {
                try
                {

                    var idq = Guid.NewGuid();
                    input.PerfilAlimentarId = idq;
                    input.UserId = id;
                    _perfilAlimentarManager.Create(ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentar>(input));

                    return RedirectToAction("Index/" + id, "PerfilAlimentar");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewPerfilAlimentarViewModel {  PerfilAlimentarInput = input });
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var perfilAlimentar = _perfilAlimentarManager.Get(id);
            if (perfilAlimentar == null)
                return null;
            var viewModel = new EditPerfilAlimentarViewModel
            {
                PageName = "Editar Perfil Alimentar",
                PerfilInList = ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentarInList>(perfilAlimentar),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "PerfilInList")] PerfilAlimentarInList input)
        {
            if (ModelState.IsValid)
            {

                _perfilAlimentarManager.Edit(ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentar>(input));
            }
            else
            {
                return View(new EditPerfilAlimentarViewModel
                {
                    PerfilInList = input
                });
            }
            return RedirectToAction("Index", "PerfilAlimentar");

        }

        public ActionResult Delete(Guid id)
        {

            var perfilAlimentar = _perfilAlimentarManager.Get(id);
            if (perfilAlimentar == null)
                return null;
            var viewModel = new DeletePerfilAlimentarViewModel
            {
                PageName = "Apagar Perfil Alimentar",
                PerfilInList = ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentarInList>(perfilAlimentar),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var perfilAlimentar = _perfilAlimentarManager.Get(id);

            if (perfilAlimentar == null)
                return null;

            _perfilAlimentarManager.Delete(perfilAlimentar);

            return RedirectToAction("Index", "PerfilAlimentar");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var perfilAlimentar = _perfilAlimentarManager.Get(id);
            if (perfilAlimentar == null)
                return null;
            var ViewModel = new DetailsPerfilAlimentarViewModel()
            {
                PageName = "Detalhes do Perfil Alimentar",
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentarInList>(perfilAlimentar);

            return View("Details", ViewModel);
        }

        private async Task<ApplicationUser> GetUserById(string id) => await _userManager.FindByIdAsync(id);




        //Admnistrador


        public async Task<IActionResult> AdminList()
        {
            var clvm = new PerfilAlimentarListViewModel { PageName = "Listagem de Perfis Alimentares " };
            try
            {
                var perfisAlimentares = _perfilAlimentarManager.GetAll().OrderBy(x => x.Data);


                //var user = await GetUserById(id);

                //clvm.UserEmail = user.Email;
                foreach (var item in perfisAlimentares)
                {
                    var user = await GetUserById(item.UserId);

                    clvm.Items.Add(new PerfilAlimentarInList
                    {

                        PerfilAlimentarId = item.PerfilAlimentarId,
                        Nome = item.Nome,
                        Data = item.Data,
                        UserEmail = user.Email
                        //UserEmail = user.Email


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
        public IActionResult NewPerfilAlimentarAdmin(string id)
        {

            return View(new NewPerfilAlimentarViewModel { PageName = "Novo PerfilAlimentar", UserId = id });
        }

        [HttpPost]
        public IActionResult NewPerfilAlimentarAdmin([FromRoute] string id, [Bind(Prefix = "PerfilAlimentarInput")]PerfilAlimentarInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var idq = Guid.NewGuid();
                    input.PerfilAlimentarId = idq;
                    input.UserId = id;
                    _perfilAlimentarManager.Create(ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentar>(input));

                    return RedirectToAction("AdminList", "PerfilAlimentar");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewPerfilAlimentarViewModel { PerfilAlimentarInput = input });
            }

        }

        public ActionResult DeletePerfilAlimentarAdmin(Guid id)
        {

            var perfilAlimentar = _perfilAlimentarManager.Get(id);
            if (perfilAlimentar == null)
                return null;
            var viewModel = new DeletePerfilAlimentarViewModel
            {
                PageName = "Apagar Perfil Alimentar",
                PerfilInList = ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentarInList>(perfilAlimentar),
            };

            return View("DeletePerfilAlimentarAdmin", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("DeletePerfilAlimentarAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedAdmin(Guid id)
        {
            var perfilAlimentar = _perfilAlimentarManager.Get(id);

            if (perfilAlimentar == null)
                return null;

            _perfilAlimentarManager.Delete(perfilAlimentar);

            return RedirectToAction("AdminList", "PerfilAlimentar");
        }





    }
}
