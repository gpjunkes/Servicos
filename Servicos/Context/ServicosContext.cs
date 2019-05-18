using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}