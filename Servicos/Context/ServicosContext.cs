using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Servicos.Map;
using Servicos.Models;

namespace Servicos.Context
{
    public class ServicosContext : DbContext
    {
        public ServicosContext()
            : base("ServicosContextoDev")
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<OrdemServico> OrdemServico { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new OrdemServicoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}