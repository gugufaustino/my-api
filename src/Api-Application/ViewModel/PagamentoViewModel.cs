using Business.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class PagamentoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string DescricaoFornecedor { get; set; }
  
        [Required]
        public TipoRecorrenciaEnum TipoRecorrencia { get; set; }
        public string TipoRecorrenciaDescricao { get; set; }
        
        [Required]
        public decimal Valor { get; set; }

        //[Required]
        public DateTime? DtVencimento { get; set; }
        public int? DiaVencimento { get; set; }

        public bool? IndPago { get; set; }
    }
}
