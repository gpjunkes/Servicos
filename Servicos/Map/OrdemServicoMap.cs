using Servicos.Models;
using System.Data.Entity.ModelConfiguration;

namespace Servicos.Map
{
    public class OrdemServicoMap : EntityTypeConfiguration<OrdemServico>
    {
        public OrdemServicoMap()
        {
            ToTable("ORDEMSERVICO");

            HasKey(x => new { x.Id });

            Property(x => x.Data)
                .HasColumnName("DATA")
                .IsRequired();

            Property(x => x.ValorTotal)
                .HasColumnName("VALORTOTAL")
                .IsRequired();

            Property(x => x.FormaPagto)
                .HasColumnName("FORMAPAGTO")
                .IsRequired();

            Property(x => x.IdPessoa)
                .HasColumnName("IDPESSOA")
                .IsRequired();

            HasRequired(x => x.Pessoa)
                .WithMany()
                .HasForeignKey(x => x.IdPessoa);
        }
    }
}