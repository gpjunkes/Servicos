using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Servicos.Context;
using Servicos.Models;
using Dapper;
using System.Configuration;

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

        public List<OrdemServicoView> ObterTodos()
        {
            var ret = new List<OrdemServicoView>();
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["ServicosContextoDev"].ConnectionString;
                conexao.Open();

                var sql = "select o.id, o.data, o.valortotal, o.formapagto, p.nome as nomepessoa"+
                          "  from ordemservico o, pessoa p "+
                          " where o.pessoa_id = p.id";

                ret = conexao.Query<OrdemServicoView>(sql).ToList();
            }

            return ret;

            //return _contexto.OrdemServico.ToList();
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