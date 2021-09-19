using System;

namespace Business.Models
{
    public class Pagamento : Entity
    {
        public int IdConta { get; set; }
        public decimal Valor { get; set; }
        public DateTime DtVencimento { get; set; }
        public decimal Saldo { get; set; }
        public bool IndPago { get; set; }

        public Conta Conta { get; set; }
    }
     
}
