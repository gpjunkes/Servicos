using Servicos.Models;
using System.Data.Entity.ModelConfiguration;

namespace Servicos.Map
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {

        public PessoaMap()
        {
            ToTable("PESSOA");

            HasKey(x => new { x.Id });

            Property(x => x.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            Property(x => x.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .IsRequired();

            Property(x => x.Sexo)
                .HasColumnName("SEXO")
                .IsRequired();

            Property(x => x.Telefone)
                .HasColumnName("TELEFONE")
                .IsRequired();

            Property(x => x.Email)
                .HasColumnName("EMAIL")
                .IsRequired();

            Property(x => x.TipoPessoa)
                .HasColumnName("TIPOPESSOA")
                .IsRequired();
        }
    }
}