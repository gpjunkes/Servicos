using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Servicos.Context;
using Servicos.Models;

namespace Servicos.Repository
{
    public class PessoaRepo
    {
        private readonly ServicosContext _contexto;

        public PessoaRepo()
        {
            _contexto = new ServicosContext();
        }

        public void Salvar(Pessoa pessoa)
        {
            _contexto.Pessoa.Add(pessoa);
            _contexto.SaveChanges();
        }

        public List<Pessoa> ObterTodos()
        {
            return _contexto.Pessoa.OrderBy(p => p.Nome).ToList();
        }

        public void Atualizar(Pessoa pessoa)
        {
            _contexto.Entry(pessoa).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(int id)
        {
            var pessoa = ObterPorId(id);
            _contexto.Pessoa.Remove(pessoa);
            _contexto.SaveChanges();
        }

        public Pessoa ObterPorId(int id)
        {
            return _contexto.Pessoa.Find(id);

        }
    }
}