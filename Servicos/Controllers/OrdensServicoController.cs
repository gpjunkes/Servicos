using System.Net;
using System.Web.Mvc;
using Servicos.Models;
using Servicos.Repository;

namespace Servicos.Controllers
{
    public class OrdensServicoController : Controller
    {
        private readonly OrdemServicoRepo _ordemServicoRepo;
        private readonly PessoaRepo _pessoaRepo;

        public OrdensServicoController()
        {
            _ordemServicoRepo = new OrdemServicoRepo();
            _pessoaRepo = new PessoaRepo();
        }

        // GET: OrdensServico
        public ActionResult Index()
        {
            return View(_ordemServicoRepo.ObterTodos());
        }

        // GET: OrdensServico/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = _ordemServicoRepo.ObterPorId(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // GET: OrdensServico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdensServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,ValorTotal,FormaPagto,IdPessoa")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                if (!this.ValidarPessoaNaOs(ordemServico))
                {
                    System.Web.HttpContext.Current.Response.Write("Pessoa não encontrada. Informe um registro existente.");
                    return View();
                }
                _ordemServicoRepo.Salvar(ordemServico);
                return RedirectToAction("Index");
            }

            return View(ordemServico);
        }

        private bool ValidarPessoaNaOs(OrdemServico ordemServico)
        {
            var pessoa = _pessoaRepo.ObterPorId(ordemServico.IdPessoa);
            return pessoa != null;
        }

        // GET: OrdensServico/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = _ordemServicoRepo.ObterPorId(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // POST: OrdensServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,ValorTotal,FormaPagto,IdPessoa")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                if (!this.ValidarPessoaNaOs(ordemServico))
                {
                    System.Web.HttpContext.Current.Response.Write("Pessoa não encontrada. Informe um registro existente.");
                    return View();
                }
                _ordemServicoRepo.Atualizar(ordemServico);
                return RedirectToAction("Index");
            }
            return View(ordemServico);
        }

        // GET: OrdensServico/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemServico ordemServico = _ordemServicoRepo.ObterPorId(id);
            if (ordemServico == null)
            {
                return HttpNotFound();
            }
            return View(ordemServico);
        }

        // POST: OrdensServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ordemServicoRepo.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
