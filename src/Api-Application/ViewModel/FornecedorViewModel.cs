using Business.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string RazaoSocial { get; set; }
  
       
    }
}
