using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.ViewModels;
using Nutrimeal.Models.QuantidadeAlimentar;
using Nutrimeal.Web.Infrastructure;
using Nutrimeal.Models;
using Nutrimeal.Models.Alimento;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Nutrimeal.Controllers
{
    public class QuantidadeAlimentarController : Controller
    {

        private readonly IQuantidadeAlimentarManager _quantidadeAlimentarManager;
        private readonly IRefeicaoManager _refeicaoManager;
        private readonly IAlimentoManager _alimentoManager;
        private readonly IPerfilAlimentarManager _perfilAlimentarManager;

        public QuantidadeAlimentarController(IQuantidadeAlimentarManager quantidadeAlimentarManager, IRefeicaoManager refeicaoManager, IAlimentoManager alimentoManager, IPerfilAlimentarManager perfilAlimentarManager)
        {
            _quantidadeAlimentarManager = quantidadeAlimentarManager;
            _refeicaoManager = refeicaoManager;
            _alimentoManager = alimentoManager;
            _perfilAlimentarManager = perfilAlimentarManager;
        }


        public IActionResult Index(Guid id)
        {
            var clvm = new QuantidadeAlimentarListViewModel { PageName = "Listagem de Quantidades Alimentares " };
            try
            {
                var quantidadesAlimentares = _quantidadeAlimentarManager.GetAll().Where(s=> s.RefeicaoId==id);

                var refeicao = _refeicaoManager.Get(id);
                

                clvm.RefeicaoNome = refeicao.Nome;
                //clvm.AlimentoNome = alimento.Nome;

                foreach (var item in quantidadesAlimentares)
                {
                    var alimento = _alimentoManager.Get(item.AlimentoId);

                    clvm.Items.Add(new QuantidadeAlimentarInList
                    {
                        QuantidadeAlimentarId = item.QuantidadeAlimentarId,
                        Quantidade = item.Quantidade,
                        TipoMedida = item.TipoMedida,
                        RefeicaoId = item.RefeicaoId,
                        AlimentoId = item.AlimentoId,
                        AlimentoNome = alimento.Nome,
                        //RefeicaoName = refeicao = _refeicaoManager.Get(item.RefeicaoId)

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
        public IActionResult New(Guid idRefeicao)
        {
            var clvm = new NewQuantidadeAlimentarViewModel { PageName = "Criar Novo Plano " };
            var clvm2 = new NewQuantidadeAlimentarViewModel { PageName = "Listagem de Alimentos " };
            try
            {
                var alimentos = _alimentoManager.GetAll();



                foreach (var item in alimentos)
                {
                    clvm2.Items.Add(new AlimentoInList
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
                return View(clvm2);
            }
            catch (Exception ex)
            {
                clvm.ErrorMessage = ex.Message;

                // TODO: Log error
            }


            return View(new NewQuantidadeAlimentarViewModel { PageName = "Nova Quantidade Alimentar" , RefeicaoId= idRefeicao });

        }

        [HttpPost]
        public ActionResult New([FromRoute] Guid id, [Bind(Prefix = "QuantidadeAlimentarInput")]QuantidadeAlimentarInList input)
        {
            var clvm = new AlimentoListViewModel { PageName = "Listagem de Alimentos " };
           


            if (ModelState.IsValid)
            {
                try
                {
                    var idQ = Guid.NewGuid();
                    input.QuantidadeAlimentarId = idQ;
                    input.RefeicaoId = id;
                    _quantidadeAlimentarManager.Create(ServicesAutoMapperConfig.Mapped.Map<QuantidadeAlimentar>(input));

                    var refeicao = _refeicaoManager.Get(id);
                    var perfilAlimentar = _perfilAlimentarManager.Get(refeicao.PerfilAlimentarId);
                    return RedirectToAction("Details/" + perfilAlimentar.PerfilAlimentarId, "PerfilAlimentar");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(new NewQuantidadeAlimentarViewModel { QuantidadeAlimentarInput = input });
            }

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var quantidadeAlimentar = _quantidadeAlimentarManager.Get(id);
            if (quantidadeAlimentar == null)
                return null;
            var viewModel = new EditQuantidadeAlimentarViewModel
            {
                PageName = "Editar Quantidade Alimentar",
                QuantidadeAlimentarToUpdate = ServicesAutoMapperConfig.Mapped.Map<QuantidadeAlimentarInList>(quantidadeAlimentar),
            };

            return View("Edit", viewModel);

        }

        [HttpPost]
        public IActionResult Edit([Bind(Prefix = "QuantidadeAlimentarToUpdate")] QuantidadeAlimentarInList input)
        {
            if (ModelState.IsValid)
            {

                _quantidadeAlimentarManager.Edit(ServicesAutoMapperConfig.Mapped.Map<QuantidadeAlimentar>(input));
            }
            else
            {
                return View(new EditQuantidadeAlimentarViewModel
                {
                    QuantidadeAlimentarToUpdate = input
                });
            }
            return RedirectToAction("Index", "QuantidadeAlimentar");

        }

        public ActionResult Delete(Guid id)
        {

            var quantidadeAlimentar = _quantidadeAlimentarManager.Get(id);
            if (quantidadeAlimentar == null)
                return null;
            var viewModel = new DeleteQuantidadeAlimentarViewModel
            {
                PageName = "Apagar Quantidade Alimentar",
                QuantidadeAlimentarToDelete = ServicesAutoMapperConfig.Mapped.Map<QuantidadeAlimentarInList>(quantidadeAlimentar),
            };

            return View("Delete", viewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var quantidadeAlimentar = _quantidadeAlimentarManager.Get(id);

            if (quantidadeAlimentar == null)
                return null;

            _quantidadeAlimentarManager.Delete(quantidadeAlimentar);

            return RedirectToAction("Index", "QuantidadeAlimentar");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
           

            var quantidadeAlimentar = _quantidadeAlimentarManager.Get(id);
            if (quantidadeAlimentar == null)
                return null;

            var idRefeicao=quantidadeAlimentar.RefeicaoId;

            var refeicao = _refeicaoManager.Get(idRefeicao);
            var ViewModel = new DetailsQuantidadeAlimentarViewModel()
            {
                PageName = "Detalhes da Quantidade Alimentar",
                Refeicao = refeicao.Nome
            };

            ViewModel.Item = ServicesAutoMapperConfig.Mapped.Map<QuantidadeAlimentarInList>(quantidadeAlimentar);

            return View("Details", ViewModel);
        }

    }
}
