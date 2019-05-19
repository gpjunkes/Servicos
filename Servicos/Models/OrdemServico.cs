using System;

namespace Servicos.Models
{
    public class OrdemServico
    {

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorTotal { get; set; }

        public string FormaPagto { get; set; }

        public int IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}