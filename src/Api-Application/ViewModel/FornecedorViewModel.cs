using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string RazaoSocial { get; set; }
        
        [Required]
        public string Cnpj { get; set; }
        
        [Required]
        public string Atividade { get; set; }
  
       
    }
}
