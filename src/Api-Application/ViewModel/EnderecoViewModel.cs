using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class EnderecoViewModel
    {
        [Required]
        public string Cep { get; set; }

        [Required]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string NomeMunicipio { get; set; }

        [Required]
        public string SiglaUf { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}