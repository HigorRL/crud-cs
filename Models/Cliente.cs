using System;

namespace CadastroClientesAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
