using System;

namespace Business.Models
{
    public class Contato : EntityKey
    {
        public string Nome { get; set; }       
        public string Telefone { get; set; }       
        public string Email { get; set; }       
    }
}
