using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class TipoSituacao :Entity
    {
        public new TipoSituacaoEnum Id { get; set; }
        public string NomeTipoSituacao { get; set; }
    }

    public enum TipoSituacaoEnum
    {
        EmElaboracao = 1    
    }
}
