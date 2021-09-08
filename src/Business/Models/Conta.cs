using Business.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Conta : Entity
    {
        public string DescricaoFornecedor { get; set; }
        public TipoContaEnum TipoConta { get; set; }
        public TipoRecorrenciaEnum TipoRecorrencia { get; set; }

        public IEnumerable<Pagamento> Pagamentos { get; set; }

    }
}
