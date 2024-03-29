﻿using System.Net;
using System.Web.Mvc;
using Servicos.Models;
using Servicos.Repository;

namespace Servicos.Controllers
{
    public class PessoasController : Controller
    {
        private readonly PessoaRepo _pessoaRepo;

        public PessoasController()
        {
            _pessoaRepo = new PessoaRepo();
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            return View(_pessoaRepo.ObterTodos());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _pessoaRepo.ObterPorId(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,NomeFantasia,Sexo,Telefone,Email,TipoPessoa")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepo.Salvar(pessoa);
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _pessoaRepo.ObterPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,NomeFantasia,Sexo,Telefone,Email,TipoPessoa")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepo.Atualizar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _pessoaRepo.ObterPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _pessoaRepo.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
