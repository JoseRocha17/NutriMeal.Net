using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.Refeicao;
using Nutrimeal.Models;
using Nutrimeal.Web.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class RefeicaoController : Controller
    {
        private readonly IRefeicaoManager _refeicaoManager;
        private readonly IPerfilAlimentarManager _perfilAlimentarManager;

        public RefeicaoController(IRefeicaoManager refeicaoManager, IPerfilAlimentarManager perfilAlimentarManager)
        {
            _refeicaoManager = refeicaoManager;
            _perfilAlimentarManager = perfilAlimentarManager;
        }

        // GET: /<controller>/
        public IActionResult Index(Guid id)
        {
            var clvm = new RefeicaoListViewModel { PageName = "Listagem de Refeições ", PerfilAlimentarId=id};
            try
            {

                var perfil = _perfilAlimentarManager.Get(id);
                clvm.PerfilAlimentarNome = perfil.Nome;
                clvm.PerfilAlimentarData = perfil.Data;
               // var refeicoes = _refeicaoManager.GetAll().Where(s => s.PerfilAlimentarId == id);

                //var q = from c in _refeicaoManager.GetAll() where c.PerfilAlimentarId == id select c;
                //var refeicoes = _refeicaoManager.GetAll().Where(s => s.PerfilAlimentarId == id).ToList();



                var refeicoes = _refeicaoManager.GetAll().Where(s=> s.PerfilAlimentarId==id);
     
               // var refe = refeicoes.Where(s => s.PerfilAlimentarId == perfil.PerfilAlimentarId);
     


                foreach (var item in refeicoes)
                {
                    
                    clvm.Items.Add(new RefeicaoInList
                    {
                        RefeicaoId = item.RefeicaoId,
                        PerfilAlimentarId = item.PerfilAlimentarId,
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
        public IActionResult New(Guid idPerfilAlimentar)
        {

            return View(new NewRefeicaoViewModel { PageName = "Nova Refeição", PerfilAlimentarId=idPerfilAlimentar });
        }

        [HttpPost]
        public ActionResult New([FromRoute] Guid id, [Bind(Prefix = "RefeicaoInput")]RefeicaoInList input)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var idr = Guid.NewGuid();
                    input.RefeicaoId = idr;
                    input.PerfilAlimentarId = id;
                    _refeicaoManager.Create(ServicesAutoMapperConfig.Mapped.Map<Refeicao>(input));
                    return RedirectToAction("Index/" + id, "Refeicao");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewRefeicaoViewModel { RefeicaoInput = input });
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var refeicao = _refeicaoManager.Get(id);
            if (refeicao == null)
                return null;
            var viewModel = new EditRefeicaoViewModel
            {
                PageName = "Editar Medição",
                RefeicaoToUpdate = ServicesAutoMapperConfig.Mapped.Map<RefeicaoInList>(refeicao),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "RefeicaoToUpdate")] RefeicaoInList input)
        {
            if (ModelState.IsValid)
            {

                _refeicaoManager.Edit(ServicesAutoMapperConfig.Mapped.Map<Refeicao>(input));
            }
            else
            {
                return View(new EditRefeicaoViewModel
                {
                    RefeicaoToUpdate = input
                });
            }
            return RedirectToAction("Index", "Refeicao");

        }

        public ActionResult Delete(Guid id)
        {

            var refeicao = _refeicaoManager.Get(id);
            if (refeicao == null)
                return null;
            var viewModel = new DeleteRefeicaoViewModel
            {
                PageName = "Apagar Refeição",
                RefeicaoInList = ServicesAutoMapperConfig.Mapped.Map<RefeicaoInList>(refeicao),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var refeicao = _refeicaoManager.Get(id);

            if (refeicao == null)
                return null;

            _refeicaoManager.Delete(refeicao);

            return RedirectToAction("Index", "Refeicao");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var refeicao = _refeicaoManager.Get(id);
            var perfil = _perfilAlimentarManager.Get(refeicao.PerfilAlimentarId);



            if (refeicao == null)
                return null;
            var ViewModel = new DetailsRefeicaoViewModel()
            {
                PageName = "Detalhes da Refeicao",
                PerfilAlimentarNome = perfil.Nome,
                PerfilAlimentarData = perfil.Data
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<RefeicaoInList>(refeicao);

            return View("Details", ViewModel);
        }
    }
}
