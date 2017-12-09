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
using Nutrimeal.Models.Refeicao;
using Nutrimeal.Models.QuantidadeAlimentar;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class PerfilAlimentarController : Controller
    {

        private readonly IPerfilAlimentarManager _perfilAlimentarManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRefeicaoManager _refeicaoManager;
        private readonly IQuantidadeAlimentarManager _quantidadeAlimentarManager;
        private readonly IAlimentoManager _alimentoManager;

        public PerfilAlimentarController(IPerfilAlimentarManager perfilAlimentarManager, UserManager<ApplicationUser> userManager, IRefeicaoManager refeicaoManager, IQuantidadeAlimentarManager quantiadadeAlimentarManager, IAlimentoManager alimentoManager)
        {
            _perfilAlimentarManager = perfilAlimentarManager;
            _userManager = userManager;
            _refeicaoManager = refeicaoManager;
            _quantidadeAlimentarManager = quantiadadeAlimentarManager;
            _alimentoManager = alimentoManager;
        }
       //Utilizador


        // GET: /<controller>/
        public async Task<IActionResult> Index(string id)
        {
            var clvm = new PerfilAlimentarListViewModel { PageName = "Listagem de Perfis Alimentares " };
            try
            {
                var perfisAlimentares = _perfilAlimentarManager.GetAll().Where(x=>x.UserId==id).OrderBy(x=>x.Data);


                //var user = await GetUserById(id);

                //clvm.UserEmail = user.Email;
                //var userId = _userManager.GetUserId(User);
                //clvm.UserId = _userManager.GetUserId(User);
                foreach (var item in perfisAlimentares)
                {
                    clvm.UserEmail = id;
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


        [HttpGet]
        public IActionResult EditRefeicaoTotalCalorias(Guid id)
        {

            var refeicao = _refeicaoManager.Get(id);
            if (refeicao == null)
                return null;
            var viewModel = new DetailsPerfilAlimentarViewModel
            {
                PageName = "Editar Medição",
                RefeicaoToUpdate = ServicesAutoMapperConfig.Mapped.Map<RefeicaoInList>(refeicao),
            };

            return View("Details", viewModel);

        }

        [HttpPost]
        public IActionResult EditRefeicaoTotalCalorias([Bind(Prefix = "RefeicaoToUpdate")] RefeicaoInList input)
        {
            if (ModelState.IsValid)
            {

                _refeicaoManager.EditCaloriasRefeicao(ServicesAutoMapperConfig.Mapped.Map<Refeicao>(input));
            }
            else
            {
                return View(new DetailsPerfilAlimentarViewModel
                {
                    RefeicaoToUpdate = input
                });
            }

                var refeicao = _refeicaoManager.Get(input.RefeicaoId);
                var perfilAlimentar = _perfilAlimentarManager.Get(refeicao.PerfilAlimentarId);
                var perfilAlimentarId = perfilAlimentar.PerfilAlimentarId;
               

            return RedirectToAction("Details/"+ perfilAlimentarId, "PerfilAlimentar");

        }

        [HttpPost]
        public IActionResult EditPerfilAlimentarTotalCalorias([Bind(Prefix = "PerfilToUpdate")] PerfilAlimentarInList input)
        {
            if (ModelState.IsValid)
            {

                _perfilAlimentarManager.EditCaloriasPerfilAlimentar(ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentar>(input));
            }
            else
            {
                return View(new DetailsPerfilAlimentarViewModel
                {
                    PerfilToUpdate = input
                });
            }

            //var refeicao = _refeicaoManager.Get(input.RefeicaoId);
            //var perfilAlimentar = _perfilAlimentarManager.Get(refeicao.PerfilAlimentarId);
            var perfilAlimentarId = input.PerfilAlimentarId;


            return RedirectToAction("Details/" + perfilAlimentarId, "PerfilAlimentar");

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
            var refeicoes = _refeicaoManager.GetAll();
            var quantidadesAlimentares = _quantidadeAlimentarManager.GetAll();


            if (perfilAlimentar == null)
                return null;

            _perfilAlimentarManager.Delete(perfilAlimentar);
            _refeicaoManager.DeletePerfilAlimentarWithRefeicao(id, refeicoes, quantidadesAlimentares);

            //foreach (var item in refeicoes)
            //{
            //    _quantidadeAlimentarManager.DeleteRefeicaoWithAlimentos(item.RefeicaoId, quantidadesAlimentares);
            //}

            return RedirectToAction("Index", "PerfilAlimentar");
        }

        [HttpGet]
        public IActionResult Details(Guid id, Guid? RefeicaoId, string RefeicaoNome, float Calorias)
        {
            var perfilAlimentar = _perfilAlimentarManager.Get(id);
            if (perfilAlimentar == null)
                return null;
            var ViewModel = new DetailsPerfilAlimentarViewModel()
            {
                PageName = "Detalhes do Perfil Alimentar",
            };

            if (RefeicaoId != null)
            {
                ViewBag.RefeicaoId = RefeicaoId.Value;  
                ViewModel.RefeicaoNome = ViewBag.RefeicaoNome = RefeicaoNome;
                ViewModel.CaloriasRefeicao = ViewBag.Calorias = Calorias;

                var quantidadeAlimentares = _quantidadeAlimentarManager.GetAll().Where(x => x.RefeicaoId == RefeicaoId);
                foreach(var item in quantidadeAlimentares)
                {
                    var alimento = _alimentoManager.Get(item.AlimentoId);
                    ViewModel.QuantidadesAlimentares.Add(new QuantidadeAlimentarInList
                    {
                        QuantidadeAlimentarId = item.QuantidadeAlimentarId,
                        Quantidade = item.Quantidade,
                        TipoMedida = item.TipoMedida,
                        RefeicaoId = item.RefeicaoId,
                        AlimentoId = item.AlimentoId,
                        AlimentoNome = alimento.Nome,
                        CaloriasDoAlimento = alimento.Calorias
                       
                    });
                }
            }


            try
            {

                var perfil = _perfilAlimentarManager.Get(id);
                //ViewModel.PerfilAlimentarNome = perfil.Nome;
                //ViewModel.PerfilAlimentarData = perfil.Data;
                // var refeicoes = _refeicaoManager.GetAll().Where(s => s.PerfilAlimentarId == id);

                //var q = from c in _refeicaoManager.GetAll() where c.PerfilAlimentarId == id select c;
                //var refeicoes = _refeicaoManager.GetAll().Where(s => s.PerfilAlimentarId == id).ToList();



                var refeicoes = _refeicaoManager.GetAll().Where(s => s.PerfilAlimentarId == id);

                // var refe = refeicoes.Where(s => s.PerfilAlimentarId == perfil.PerfilAlimentarId);



                foreach (var item in refeicoes)
                {

                    ViewModel.Items.Add(new RefeicaoInList
                    {
                        RefeicaoId = item.RefeicaoId,
                        PerfilAlimentarId = item.PerfilAlimentarId,
                        Nome = item.Nome,
                        TotalCalorias = item.TotalCalorias
                        
                    });
                }

            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message;
                // TODO: Log error
            }



            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<PerfilAlimentarInList>(perfilAlimentar);

            return View("Details", ViewModel);
        }

        private async Task<ApplicationUser> GetUserById(string id) => await _userManager.FindByIdAsync(id);

        


        //Admnistrador


        public async Task<IActionResult> AdminList(string id)
        {
            var clvm = new PerfilAlimentarListViewModel { PageName = "Listagem de Perfis Alimentares " };
            try
            {
                var perfisAlimentares = _perfilAlimentarManager.GetAll().Where(x=> x.UserId==id).OrderBy(x => x.Data);


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

        public async Task<IActionResult> ListAllPerfisAlimentares()
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

                    return RedirectToAction("AdminList/" +id, "PerfilAlimentar");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewPerfilAlimentarViewModel { PerfilAlimentarInput = input, UserId=id });
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
            var refeicoes = _refeicaoManager.GetAll().Where(x=>x.PerfilAlimentarId ==id).ToList();


            var quantidadesAlimentares = _quantidadeAlimentarManager.GetAll();


            if (perfilAlimentar == null)
                return null;

            _perfilAlimentarManager.Delete(perfilAlimentar);

                _refeicaoManager.DeletePerfilAlimentarWithRefeicao(id, refeicoes, quantidadesAlimentares);

            //foreach (var item in refeicoes)
            //{
            //    _quantidadeAlimentarManager.DeleteRefeicaoWithAlimentos(item.RefeicaoId, quantidadesAlimentares);
            //}

            return RedirectToAction("AdminList", "PerfilAlimentar");
        }


    }
}
