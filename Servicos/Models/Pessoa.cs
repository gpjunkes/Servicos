using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicos.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int TipoPessoa { get; set; }


        //id, nome, nome fantasia, sexo, telefone, email, 
        //tipo pessoa(Fisica, Juridica, Exportacao - pode ser um passaporte)
    }
}