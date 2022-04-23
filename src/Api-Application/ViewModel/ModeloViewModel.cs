using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class ModeloViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DtNascimento { get; set; }

        [Required]
        public string Rg { get; set; }
        
        [Required]
        public string Cpf { get; set; }

        public string Diponibilidade { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Instagram { get; set; }

        public string Facebook { get; set; }

        public string Linkedin { get; set; }


        [Required]
        public int Altura { get; set; }

        [Required]
        public int Peso { get; set; }
        public int Manequim { get; set; }
        
        [Required]
        public int Sapato { get; set; }

        [Required]
        public CorOlhosEnum CorOlhos { get; set; }
        public string NomeCorOlhos { get; set; }

        [Required]
        public CorCabeloEnum CorCabelo { get; set; }
        public string NomeCorCabelo { get; set; }

        [Required]
        public TipoCabeloEnum TipoCabelo { get; set; }
        public string NomeTipoCabelo { get; set; }

        [Required]
        public TipoCabeloComprimentoEnum TipoCabeloComprimento { get; set; }
        public string NomeTipoCabeloComprimento { get; set; }

        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<TipoCastingEnum> TipoCasting { get; set; }
        public string[] NomeTipoCasting { get; set; }
        
        public string ImagemPerfilNome { get; set; }
        public string ImagemPerfilUpload { get; set; }

    }
}
