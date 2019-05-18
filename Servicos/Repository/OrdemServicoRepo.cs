using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Servicos.Context;
using Servicos.Models;

namespace Servicos.Repository
{
    public class OrdemServicoRepo
    {
        private readonly ServicosContext _contexto;

        public OrdemServicoRepo()
        {
            _contexto = new ServicosContext();
        }

        public void Salvar(OrdemServico ordemServico)
        {
            _contexto.OrdemServico.Add(ordemServico);
            _contexto.SaveChanges();
        }

        public List<OrdemServico> ObterTodos()
        {
            return _contexto.OrdemServico.ToList();
        }

        public void Atualizar(OrdemServico ordemServico)
        {
            _contexto.Entry(ordemServico).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(int id)
        {
            var ordemServico = ObterPorId(id);
            _contexto.OrdemServico.Remove(ordemServico);
            _contexto.SaveChanges();
        }

        public OrdemServico ObterPorId(int id)
        {
            return _contexto.OrdemServico.Find(id);

        }
    }
}