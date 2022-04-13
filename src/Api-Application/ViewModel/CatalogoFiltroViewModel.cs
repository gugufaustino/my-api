using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class CatalogoFiltroViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
         

    }
}
