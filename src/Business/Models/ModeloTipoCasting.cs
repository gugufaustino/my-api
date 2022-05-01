using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ModeloTipoCasting : EntityKey
    {
        public int IdTipoCasting { get; set; }
        public int IdModelo { get; set; }
        public Modelo Modelo { get; set; }
        public TipoCasting TipoCasting { get; set; }
    }
}
