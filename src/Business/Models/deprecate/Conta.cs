using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Conta : EntityKey
    {
        public string DescricaoFornecedor { get; set; }
        public TipoContaEnum TipoConta { get; set; }
        public TipoRecorrenciaEnum TipoRecorrencia { get; set; }

        public IEnumerable<Pagamento> Pagamentos { get; set; }

    }

    public enum TipoContaEnum
    {
        APagar = 1,
        AReceber = 2
    }

    public enum TipoRecorrenciaEnum
    {
        Unico = 1,
        Mensal = 2,
        Anual = 3,
    }
}
