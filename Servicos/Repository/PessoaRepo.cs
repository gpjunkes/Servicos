using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
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
            //var ret = new List<Pessoa>();
            //using (var conexao = new SqlConnection())
            //{
            //    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["ServicosContextoDev"].ConnectionString;
            //    conexao.Open();

            //    var sql = "select * from pessoa p" +
            //              " order by p.nome";

            //    ret = conexao.Query<Pessoa>(sql).ToList();
            //}

            //return ret;

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
            var ret = new Pessoa();
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["ServicosContextoDev"].ConnectionString;
                conexao.Open();

                var sql = "select * from pessoa p" +
                          " where p.id = " + id;

                ret = conexao.Query<Pessoa>(sql).FirstOrDefault();
            }

            return ret;

        }
    }
}