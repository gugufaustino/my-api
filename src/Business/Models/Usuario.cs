using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Imagem { get; set; }


    }
}
