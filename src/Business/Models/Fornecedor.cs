using System;

namespace Business.Models
{
    public class Fornecedor : Entity
    {
        public int IdEndereco { get; set; }
        public string RazaoSocial { get; set; }       
        public string Cnpj { get; set; }       
        public string Atividade { get; set; }       

        public Endereco Endereco { get; set; }
    }
}
