using System.Collections.Generic;

namespace Business.Models
{
    public class Agencia : EntityKey
    {
        public Agencia()
        {

        }
        /// <summary>
        /// Constroi Agencia Tipo AgenteAutonomo 
        /// </summary>
        /// <param name="nome"></param>
        public Agencia(string nome)
        {
            NomeAgencia = nome;
            TipoCadastro = TipoAgenciaEnum.AgenteAutonomo;
        }

        /// <summary>
        /// Constroi Agencia Tipo Agencia
        /// </summary>
        public Agencia(string razaoSocial, string cnpj, string nomeFantasia, string instagram, string email)  
        {
           
            NomeAgencia = nomeFantasia;
            Instagram = instagram;
            TipoCadastro = TipoAgenciaEnum.AgenciaEmpresa;

            AgenciaEmpresa = new AgenciaEmpresa
            {
                RazaoSocial = razaoSocial,
                Cnpj = cnpj,
                NomeFantasia = nomeFantasia,
                Email = email
            };

        }

        public string NomeAgencia { get; set; }
        public string Instagram { get; set; }
        public TipoAgenciaEnum TipoCadastro { get; set; }
        public TipoSituacaoEnum TipoSituacao { get; set; }
        public AgenciaEmpresa AgenciaEmpresa { get; set; }
        public IEnumerable<Usuario> Usuario { get; set; }
    }

    public enum TipoAgenciaEnum
    {
        AgenteAutonomo = 1,
        AgenciaEmpresa = 2,
    }
}
