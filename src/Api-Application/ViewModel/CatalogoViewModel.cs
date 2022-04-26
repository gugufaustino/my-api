using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class CatalogoViewModel
    {
        public int Id { get; set; }
        
       
        public string Nome { get; set; }

       
        public DateTime DtNascimento { get; set; }

       
        public string Rg { get; set; }
        
       
        public string Cpf { get; set; }

        public string Diponibilidade { get; set; }
        
       
        public string Email { get; set; }
        
       
        public string Telefone { get; set; }

       
        public string Instagram { get; set; }

        public string Facebook { get; set; }

        public string Linkedin { get; set; }


       
        public int Altura { get; set; }

       
        public int Peso { get; set; }
        public int Manequim { get; set; }
        
       
        public int Sapato { get; set; }

       
        public CorOlhosEnum CorOlhos { get; set; }
        public string NomeCorOlhos { get; set; }

       
        public CorCabeloEnum CorCabelo { get; set; }
        public string NomeCorCabelo { get; set; }

       
        public TipoCabeloEnum TipoCabelo { get; set; }
        public string NomeTipoCabelo { get; set; }

       
        public TipoCabeloComprimentoEnum TipoCabeloComprimento { get; set; }
        public string NomeTipoCabeloComprimento { get; set; }

        public EnderecoViewModel Endereco { get; set; }
        //public IEnumerable<TipoCastingEnum> ModeloTipoCasting { get; set; }
        public string[] NomeTipoCasting { get; set; }
        
        public string ImagemPerfilNome { get; set; }
        public string ImagemPerfilUpload { get; set; }

    }
}
