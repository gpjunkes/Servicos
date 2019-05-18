using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Servicos.Models;

namespace Servicos.Data
{
    public class ServicosContexto : DbContext
    {
        public ServicosContexto()
            : base("ServicosContextoDev")
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}