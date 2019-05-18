namespace Servicos.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string NomeFantasia { get; set; }

        public EnumSexo Sexo { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public EnumTipoPessoa TipoPessoa { get; set; }

    }

    public enum EnumSexo
    {
        Masculino = 0,
        Feminino = 1
    }

    public enum EnumTipoPessoa
    {
        Fisica = 0,
        Juridica = 1,
        Exportacao = 2
    }
}