using Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class ContaViewModel
    {
        [Required]
        public string DescricaoFornecedor { get; set; }

        [Required]
        public TipoContaEnum TipoConta { get; set; }

        [Required]
        public TipoRecorrenciaEnum TipoRecorrencia { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DtVencimento { get; set; }
        
        public bool IndPago { get; set; }

    }
}
