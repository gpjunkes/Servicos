using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicos.Models
{
    public class OrdemServicoView
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorTotal { get; set; }

        public string FormaPagto { get; set; }

        public string NomePessoa { get; set; }
    }
}