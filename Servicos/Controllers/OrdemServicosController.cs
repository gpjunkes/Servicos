using System.Net;
using System.Web.Mvc;
using Servicos.Models;
using Servicos.Repository;

namespace Servicos.Controllers
{
    public class OrdemServicosController : Controller
    {
        private readonly OrdemServicoRepo _ordemServicoRepo;

        public OrdemServicosController()
        {
            _ordemServicoRepo = new OrdemServicoRepo();
        }

        // GET: OrdemServicos
        public ActionResult Index()
        {
            return View(_ordemServicoRepo.ObterTodos());
        }

        // GET: OrdemServicos/Details/5
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

        // GET: OrdemServicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdemServicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,ValorTotal,FormaPagto")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                _ordemServicoRepo.Salvar(ordemServico);
                return RedirectToAction("Index");
            }

            return View(ordemServico);
        }

        // GET: OrdemServicos/Edit/5
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

        // POST: OrdemServicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,ValorTotal,FormaPagto")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                _ordemServicoRepo.Atualizar(ordemServico);
                return RedirectToAction("Index");
            }
            return View(ordemServico);
        }

        // GET: OrdemServicos/Delete/5
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

        // POST: OrdemServicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ordemServicoRepo.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
