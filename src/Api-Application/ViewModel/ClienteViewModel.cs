using System;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }


    }
}
